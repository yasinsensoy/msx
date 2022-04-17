<?php
	if(!isset($_GET["islem"]) || !isset($_GET["dad"]) || !isset($_GET["sad"]) || !isset($_GET["did"]) || !isset($_GET["sno"]) || $_GET["islem"] != "1")
		exit();
	include('db.php');
	include('cf.php');
	header('Content-Type: application/json');
	$data = '{"type": "list","extension": "'.$kadi.'","headline": "'.$_GET["dad"].' - '.$_GET["sad"].'","template": {"type": "default","layout": "0,0,2,2","tagColor": "msx-black","badgeColor": "msx-green","progressColor": "msx-green","icon": "play-circle-outline","alignment": "center","iconSize": "medium"},"items": [';
	$statement = $baglanti->prepare("SELECT b.id,b.bno,b.tip,b.video,i.izle,i.sure,i.uzunluk FROM (SELECT id,bno,tip,video FROM bolum WHERE did=".$_GET["did"]." AND sno=".$_GET["sno"].") AS b LEFT JOIN (SELECT mid,izle,sure,uzunluk FROM izleme WHERE tip='d' AND kid=".$_COOKIE["kid"]." GROUP BY mid) AS i ON b.id=i.mid ORDER BY b.bno DESC");
	$statement->execute();
	$statement->bind_result($id, $bno, $tip, $video, $izle, $sure, $uzunluk);
	$say = 0;
	while($statement->fetch()) {
		$say += 1;
		$data .= ($say > 1 ? ',' : '');
		$ad = $bno.".Bölüm";
		$data .= '{"titleHeader": "{txt:msx-white:'.$ad.'}",';
		if(isset($izle) && $izle)
			$data .= '"badge": "{txt:msx-white:İZLENDİ}",';
		if($tip == 's' || $tip == 'f')
			$data .= '"tag": "{txt:msx-'.($tip == 's' ? 'yellow:SEZON' : 'red:FİNAL').'}",';
		if(isset($sure) && $sure > 0 && $uzunluk >= $sure)
			$data .= '"progress": '.($sure / $uzunluk).',';
		$pad = $_GET["dad"].' - '.$_GET["sad"].' - '.$ad;
		$data .= '"action": "execute:user:'.$msx.'ayrinti.php?islem=1&tip=d&yid=&id='.$id.'&ad='.$pad.'&video='.$video.'"}';
	}
	$data .= ']}';
	mysqli_close($baglanti);
	echo $data;
?>