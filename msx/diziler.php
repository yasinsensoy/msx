<?php
	if(!isset($_GET["islem"]) || !isset($_GET["tur"]) || $_GET["islem"] != "1" || ($_GET["tur"] != "Yerli" && $_GET["tur"] != "Yabancı"))
		exit();
	include('db.php');
	include('cf.php');
	header('Content-Type: application/json');
	$data = '{"type": "list","extension": "'.$kadi.'","headline": "'.$_GET["tur"].' Diziler","template": {"type": "default","badgeColor": "msx-green","layout": "0,0,4,6"},"items": [';
	$statement = $baglanti->prepare("SELECT id,ad,resim,DiziIzlendiKontrol(id,".$_COOKIE["kid"].") AS izlendi FROM dizi WHERE tur='".$_GET["tur"]."' ORDER BY izlendi,ad");
	$statement->execute();
	$statement->bind_result($id, $ad, $resim, $izlendi);
	$say = 0;
	while($statement->fetch()) {
		$say += 1;
		$data .= ($say > 1 ? ',' : '');
		$data .= '{"titleHeader": "{txt:msx-white:'.$ad.'}",';
		if($izlendi)
			$data .= '"badge": "{txt:msx-white:İZLENDİ}",';		
		$data .= '"image": "'.$msx.($resim == ""?'img/diziafis.png':$resim).'",';
		$data .= '"action": "execute:'.$msx.'sezonlar.php?islem=1&dad='.$ad.'&did='.$id.'&kid='.$_COOKIE["kid"].'"}';
	}
	$data .= ']}';
	mysqli_close($baglanti);
	echo '{"response": {"status": 200,"text": "OK","message": null,"data": {"action": "'.($say == 0 ? 'error:Dizi bulunamadı"' : 'content:data","data": '.$data).'}}}';
?>