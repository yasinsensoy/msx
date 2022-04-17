<?php
	include('db.php');
	include('cf.php');
	header('Content-Type: application/json');	
	$data = '{"type": "list","headline": "Kullanıcılar","template": {"type": "default","layout": "0,0,2,3","icon": "person","alignment": "center","iconSize": "large"},"items": [';
	$statement = $baglanti->prepare("SELECT id,ad FROM kullanici ORDER BY ad");
	$statement->execute();
	$statement->bind_result($id, $ad);
	$say = 0;
	while($statement->fetch()) {
		$say += 1;
		$data .= ($say > 1 ? ',' : '');
		$data .= '{"titleHeader": "{txt:msx-white:'.$ad.'}",';
		if(isset($_COOKIE["kid"]) && $_COOKIE["kid"] == $id)
			$data .= '"focus": true,';
		$data .= '"action": "content:user:'.$msx.'giris.php?islem=1&kadi='.$ad.'&kid='.$id.'"}';
	}
	if($say == 0)
		$data = '{"type": "list","headline": "Kullanıcılar","pages": [{"items": [{"type": "default","layout": "0,0,12,6","headline": "{ico:error} Kullanıcı bulunamadı.","action": "reload:content"}]}';
	$data .= ']}';
	mysqli_close($baglanti);
	echo $data;
?>