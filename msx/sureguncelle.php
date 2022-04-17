<?php
	if ($_SERVER['REQUEST_METHOD'] != 'POST' || !isset($_POST["sure"]) || !isset($_POST["tsure"]) || !isset($_POST["iid"]) || !isset($_POST["mid"]) || !isset($_POST["tip"]))
		exit();
	include('db.php');
	include('cf.php');
	if($_POST["iid"] == 0) {
		$baglanti->query("INSERT INTO izleme(tarih,sure,uzunluk,izle,kid,mid,tip) VALUES(now(),".$_POST["sure"].",".$_POST["tsure"].",0,".$_COOKIE["kid"].",".$_POST["mid"].",'".$_POST["tip"]."')");
		header("iid: ".$baglanti->insert_id);
		echo $baglanti->error;
	}
	else
		$baglanti->query("UPDATE izleme SET sure=".$_POST["sure"].",uzunluk=".$_POST["tsure"].",tarih=now()".($_POST["tsure"] > 0 && 0.88 < ($_POST["sure"] / $_POST["tsure"]) ? ",izle=1" : "")." WHERE id=".$_POST["iid"]);
?>