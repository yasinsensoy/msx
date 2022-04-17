<?php
	if(!isset($_GET["islem"]) || !isset($_GET["tad"]) || !isset($_GET["sgad"]) || !isset($_GET["spad"]) || !isset($_GET["sad"]) || !isset($_GET["stip"]) || !isset($_GET["turler"]) || !isset($_GET["yil"]) || !isset($_GET["tur"]) || !isset($_GET["tip"]) || $_GET["islem"] != "1" || ($_GET["tur"] != "Yerli" && $_GET["tur"] != "Yabancı"))
		exit();	
	include('db.php');
	include('cf.php');
	header('Content-Type: application/json');
	$tip = ($_GET["tip"] == "f" ? "film" : "dizi");
	$data = '{"type": "list","headline": "Filtre","template": {"type": "control","layout": "0,0,4,1"},"items": [';
	if($_GET["sad"] == '') {
		$siralama = array(array("Ad (A-Z)","ad ASC"), array("Ad (Z-A)","ad DESC"), array("Yıl (0-9)","yil ASC"), array("Yıl (9-0)","yil DESC"), array("Eklenme (0-9)","id ASC"), array("Eklenme (9-0)","id DESC"));
		$say = 0;
		foreach($siralama as $arr) {
			$say += 1;
			$data .= ($say > 1 ? ',' : '');
			$data .= '{"label": "'.$arr[0].'",'.($_GET["sgad"] == $arr[0] ? '"focus": true,"extensionIcon": "check",' : '');	
			$data .= '"action": "content:user:'.$msx.$tip.'ler.php?islem=1&sayfa=1&sgad='.$arr[0].'&spad='.$arr[1].'&tur='.$_GET["tur"].'&turler='.$_GET["turler"].'&yil='.$_GET["yil"].'"}';
		}
	}
	else {
		$statement = $baglanti->prepare("SELECT ".$_GET["sad"]." FROM ".$_GET["tad"].($_GET["sad"] == "yil" ? "" : " WHERE tip='".$_GET["tip"]."' AND mid IN (SELECT id FROM ".$tip." WHERE tur='".$_GET["tur"]."')")." GROUP BY ".$_GET["sad"]." ORDER BY ".$_GET["sad"]." ".$_GET["stip"]);
		$statement->execute();
		$statement->bind_result($ad);
		$data .= '{"label": "Tümü",'.(($_GET["turler"] == 'Tümü' && $_GET["sad"] == 'tur') || ($_GET["yil"] == 'Tümü' && $_GET["sad"] == 'yil') ? '"extensionIcon": "check",' : '');	
		$data .= '"action": "content:user:'.$msx.$tip.'ler.php?islem=1&sayfa=1&sgad='.$_GET["sgad"].'&spad='.$_GET["spad"].'&tur='.$_GET["tur"].'&turler='.($_GET["sad"] == 'tur' ? 'Tümü' : $_GET["turler"]).'&yil='.($_GET["sad"] == 'yil' ? 'Tümü' : $_GET["yil"]).'"}';
		while($statement->fetch()) {
			$data .= ',{"label": "'.$ad.'",';
			if(($_GET["turler"] == $ad && $_GET["sad"] == 'tur') || ($_GET["yil"] == $ad && $_GET["sad"] == 'yil'))
				$data .= '"focus": true,"extensionIcon": "check",';
			$data .= '"action": "content:user:'.$msx.$tip.'ler.php?islem=1&sayfa=1&sgad='.$_GET["sgad"].'&spad='.$_GET["spad"].'&tur='.$_GET["tur"].'&turler='.($_GET["sad"] == 'tur' ? $ad : $_GET["turler"]).'&yil='.($_GET["sad"] == 'yil' ? $ad : $_GET["yil"]).'"}';
		}
	}
	$data .= ']}';
	mysqli_close($baglanti);
	echo '{"response": {"status": 200,"text": "OK","message": null,"data": {"action": "panel:data","data": '.$data.'}}}';
?>