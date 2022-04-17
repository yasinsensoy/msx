<?php
	if(!isset($_GET["islem"]) || !isset($_GET["tur"]) || $_GET["islem"] != "1")
		exit();
	include('db.php');
	include('cf.php');
	header('Content-Type: application/json');
	$tz = new DateTimeZone('Europe/Istanbul');
	$zaman = new DateTime('NOW',$tz);
	$date = new DateTime('2021-12-13 17:59:00',$tz);
	$date->setTimezone($tz);
	$kalan = $zaman->diff($date);
	$deger = '{txt:msx-'.($date < $zaman ? 'red:Kanallar çalışmıyor.' : 'green:Kalan Süre: '.($kalan->y > 0 ? $kalan->y.' yıl ' : '').($kalan->m > 0 ? $kalan->m.' ay ' : '').($kalan->d > 0 ? $kalan->d.' gün ' : '').$kalan->format('%H:%I:%S'));
	$data = '{"type": "list","headline": "'.$_GET["tur"].'","extension": "'.$deger.'}","template": {"type": "default","layout": "0,0,6,1","imageWidth": "1","imageFiller": "fit","alignment": "left"},"items": [';
	$filtre = "";
	if($_GET["tur"] != "Tümü")
		$filtre = " WHERE tur='".$_GET["tur"]."'";
	$statement = $baglanti->prepare("SELECT ad,id,logo FROM kanal".$filtre." ORDER BY tur,ad");
	$statement->execute();
	$statement->bind_result($ad, $id, $logo);
	$say = 0;
	while($statement->fetch()) {
		if($_COOKIE["kid"] != 1 && ($id == 69829 || $id == 69677 || $id == 69725))
			continue;
		$say += 1;
		$data .= ($say > 1 ? ',' : '');
		$data .= '{"titleHeader": "{txt:msx-black:'.$ad.'}",';
		$data .= '"playerLabel": "'.$ad.'",';
		$data .= '"color": "msx-white",';
		$data .= '"image": "'.$msx.($logo == '' ? 'img/kanallogo.png' : $logo).'",';
		$data .= '"action": "video:http://ftnh1881.xyz:8080/yasinsensoy/BdV4CwmwwA/'.$id.'",';
        $data .= '"properties": {"label:duration": "{ico:msx-red:fiber-manual-record}Canlı","label:extension": "{ico:msx-red:live-tv}"}}';
	}
	$data .= ']}';
	mysqli_close($baglanti);
	echo '{"response": {"status": 200,"text": "OK","message": null,"data": {"action": "'.($say == 0 ? 'error:Kanal bulunamadı"' : 'content:data","data": '.$data).'}}}';
?>