<?php
	if(!isset($_GET["islem"]) || !isset($_GET["dad"]) || !isset($_GET["did"]) || !isset($_GET["kid"]) || $_GET["islem"] != "1")
		exit();
	include('db.php');
	include('cf.php');
	header('Content-Type: application/json');
	$data = '{"type": "list","headline": "'.$_GET["dad"].'","template": {"type": "default","layout": "0,0,2,2","icon": "movie","badgeColor": "msx-green","alignment": "center","iconSize": "medium"},"items": [';
	$statement = $baglanti->prepare("SELECT sno,SezonIzlendiKontrol(sno,".$_GET["did"].",".$_GET["kid"].") AS izlendi FROM bolum WHERE did=".$_GET["did"]." GROUP BY sno ORDER BY sno DESC");
	$statement->execute();
	$statement->bind_result($sno, $izlendi);
	$say = 0;
	while($statement->fetch()) {
		$say += 1;
		$data .= ($say > 1 ? ',' : '');
		$ad = $sno.".Sezon";
		$data .= '{"titleHeader": "{txt:msx-white:'.$ad.'}",';
		if($izlendi)
			$data .= '"badge": "{txt:msx-white:İZLENDİ}",';
		$data .= '"action": "content:user:'.$msx.'bolumler.php?islem=1&dad='.$_GET["dad"].'&sad='.$ad.'&did='.$_GET["did"].'&sno='.$sno.'"}';
	}
	$data .= ']}';
	mysqli_close($baglanti);
	echo '{"response": {"status": 200,"text": "OK","message": null,"data": {"action": "'.($say == 0 ? 'error:Sezon bulunamadı"' : 'panel:data","data": '.$data).'}}}';
?>