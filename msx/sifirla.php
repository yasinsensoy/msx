<?php
	if(!isset($_GET["islem"]) || !isset($_GET["tip"])  || !isset($_GET["kid"]) || !isset($_GET["mid"]) || $_GET["islem"] != "1")
		exit();
	include('db.php');
	include('cf.php');
	header('Content-Type: application/json');
	$sonuc = $baglanti->query("UPDATE izleme SET sure=0,uzunluk=0,tarih=null WHERE tip='".$_GET["tip"]."' AND kid=".$_GET["kid"]." AND mid=".$_GET["mid"]);
	mysqli_close($baglanti);
	echo '{"response": {"status": 200,"text": "OK","message": null,"data": {"action": "['.($sonuc ? 'info:İzleme süreleri sıfırlandı.' : 'error:Hata oluştu').'|reload:content|back]"}}}';
?>