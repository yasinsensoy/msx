<?php
	if(!isset($_GET["islem"]) || !isset($_GET["tip"]) || !isset($_GET["tur"]) || !isset($_GET["kid"]) || !isset($_GET["mid"]) || $_GET["islem"] != "1")
		exit();
	include('db.php');
	include('cf.php');
	header('Content-Type: application/json');
	if($_GET["tur"] == 'e')
		$sonuc = $baglanti->query("INSERT INTO izleme(izle,kid,mid,tip) VALUES(1,".$_GET["kid"].",".$_GET["mid"].",'".$_GET["tip"]."')");
	else
		$sonuc = $baglanti->query("UPDATE izleme SET izle=".($_GET["izle"] ? 0 : 1)." WHERE tip='".$_GET["tip"]."' AND kid=".$_GET["kid"]." AND mid=".$_GET["mid"]);
	mysqli_close($baglanti);
	echo '{"response": {"status": 200,"text": "OK","message": null,"data": {"action": "['.($sonuc ? 'info:'.($_GET["tur"] == 'e' || $_GET["tur"] == 'g' ? 'İzlediklerine eklendi' : 'İzlediklerinden çıkarıldı') : 'error:Hata oluştu').'|reload:content|back]"}}}';
?>