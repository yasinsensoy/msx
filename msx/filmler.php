<?php
	if(!isset($_GET["islem"]) || !isset($_GET["sayfa"]) || !isset($_GET["tur"]) || !isset($_GET["sgad"]) || !isset($_GET["spad"]) || !isset($_GET["turler"]) || !isset($_GET["yil"]) || $_GET["islem"] != "1" || ($_GET["tur"] != "Yerli" && $_GET["tur"] != "Yabancı"))
		exit();	
	setcookie("sgad", $_GET["sgad"]);
	setcookie("spad", $_GET["spad"]);
	include('db.php');
	include('cf.php');
	header('Content-Type: application/json');
	$filtre = "";
	if($_GET["turler"] != "Tümü")
		$filtre = " AND id IN (SELECT mid FROM turler WHERE tur='".$_GET["turler"]."')";
	if($_GET["yil"] != "Tümü")
		$filtre .= " AND yil=".$_GET["yil"];
	$sayfa = $_GET["sayfa"];
	$statement = $baglanti->prepare("SELECT COUNT(id) FROM film WHERE tur='".$_GET["tur"]."'".$filtre);
	$statement->execute();
	$statement->bind_result($count);
	$statement->fetch();
	$say = 0;
	$baslik = $_GET["turler"].' - '.$_GET["yil"].' - Sayfa '.$sayfa;
	$siralama = array(array("Türler",$_GET["turler"],"turler","tur","ASC"), array("Yıllar",$_GET["yil"],"film","yil","DESC"), array("Sıralama",$_GET["sgad"],"","",""));	
	$datafiltre = "";
	foreach($siralama as $arr) {			
		$datafiltre .= ($say > 0 ? ',' : '');
		$datafiltre .= '{"type": "control","layout": "'.$say.',0,4,1","label": "'.$arr[0].'","extensionLabel": "'.$arr[1].'","action": "execute:user:'.$msx.'filtre.php?islem=1&tad='.$arr[2].'&sad='.$arr[3].'&stip='.$arr[4].'&tip=f&sgad='.$_GET["sgad"].'&spad='.$_GET["spad"].'&yil='.$_GET["yil"].'&turler='.$_GET["turler"].'&tur='.$_GET["tur"].'","selection": {"action": "[update:content:overlay:ozet|update:content:overlay:kalan]","data": {"titleFooter": "","progress":0,"text": ""}}}';
		$say += 4;
	}
	$say = 0;
	if(isset($count) && $count > 0)
	{
		$sonsayfa = ceil($count / 25);
		$statement->fetch();		
		$data = '{"type": "list","headline": "'.$baslik.'","extension": "'.$kadi.'",';	
		$data .= '"template": {"type": "default","layout": "0,0,4,6","badgeColor": "msx-black","area": "0,0,4,6"},';
		$data .= '"overlay": {"items": [{"id": "ozet","type": "space","layout": "4,0,8,5","offset": "0,0,0,0.6","text": ""},{"id": "kalan","type": "space","alignment": "right","layout": "4,5,8,1","offset": "0,0.5,0,-0.5","progressColor": "","titleFooter": "","progress": 0}]},"header": {"headline": "Filtrele","items": [';
		$datasayfa = "";
		$say = -3;
		if($sonsayfa > 1) {
			$datasayfa = '"footer": {"headline": "Sayfa Seç","items": [';
			$datasayfa .= $sayfa == $sonsayfa ? '' : '{"type": "control","layout": "'.($say+=3).',0,3,1","label": "Sonraki Sayfa ('.($sayfa + 1).')","extensionIcon": "arrow-forward","action": "content:user:'.$msx.'filmler.php?islem=1&tur='.$_GET["tur"].'&sayfa='.($sayfa + 1).'&sgad='.$_GET["sgad"].'&spad='.$_GET["spad"].'&turler='.$_GET["turler"].'&yil='.$_GET["yil"].'","selection": {"action": "[update:content:overlay:ozet|update:content:overlay:kalan]","data": {"titleFooter": "","progress":0,"text": ""}}},';
			$datasayfa .= $sayfa == 1 ? '' : '{"type": "control","layout": "'.($say+=3).',0,3,1","label": "Önceki Sayfa ('.($sayfa - 1).')","extensionIcon": "arrow-back","action": "content:user:'.$msx.'filmler.php?islem=1&tur='.$_GET["tur"].'&sayfa='.($sayfa - 1).'&sgad='.$_GET["sgad"].'&spad='.$_GET["spad"].'&turler='.$_GET["turler"].'&yil='.$_GET["yil"].'","selection": {"action": "[update:content:overlay:ozet|update:content:overlay:kalan]","data": {"titleFooter": "","progress":0,"text": ""}}},';
			$datasayfa .= $sayfa == 1 ? '' : '{"type": "control","layout": "'.($say+=3).',0,3,1","label": "İlk Sayfa (1)","extensionIcon": "first-page","action": "content:user:'.$msx.'filmler.php?islem=1&tur='.$_GET["tur"].'&sayfa=1&sgad='.$_GET["sgad"].'&spad='.$_GET["spad"].'&turler='.$_GET["turler"].'&yil='.$_GET["yil"].'","selection": {"action": "[update:content:overlay:ozet|update:content:overlay:kalan]","data": {"titleFooter": "","progress":0,"text": ""}}}'.($sayfa == $sonsayfa ? '' : ',');
			$datasayfa .= $sayfa == $sonsayfa ? '' : '{"type": "control","layout": "'.($say+=3).',0,3,1","label": "Son Sayfa ('.$sonsayfa.')","extensionIcon": "last-page","action": "content:user:'.$msx.'filmler.php?islem=1&tur='.$_GET["tur"].'&sayfa='.$sonsayfa.'&sgad='.$_GET["sgad"].'&spad='.$_GET["spad"].'&turler='.$_GET["turler"].'&yil='.$_GET["yil"].'","selection": {"action": "[update:content:overlay:ozet|update:content:overlay:kalan]","data": {"titleFooter": "","progress":0,"text": ""}}}';
			$datasayfa .= ']},';
		}
		$data .= $datafiltre.']},'.$datasayfa.'"items": [';	
		$limit = ($sayfa - 1) * 25;
		$statement = $baglanti->prepare("SELECT f.id,f.ad,f.orjad,f.dil,f.yil,f.imdb,f.turler,f.ozet,f.fragman,f.resim,f.cover,f.video,i.sure,i.uzunluk,IF(ISNULL(i.izle) OR (i.izle=0 AND i.sure=0),1,IF(i.izle=0 AND i.sure>0,0,2)) AS sira FROM (SELECT *,(SELECT GROUP_CONCAT(tur) FROM turler WHERE mid=fi.id) AS turler FROM film AS fi WHERE tur='".$_GET["tur"]."'".$filtre.") AS f LEFT JOIN (SELECT * FROM izleme WHERE tip='f' AND kid=".$_COOKIE["kid"].") AS i ON f.id=i.mid ORDER BY sira, IF(ISNULL(i.tarih),'0000-00-00 00:00:00',i.tarih) DESC, f.".$_GET["spad"]." LIMIT ".$limit.",25");
		$statement->execute();
		$statement->bind_result($id, $ad, $orjad, $dil, $yil, $imdb, $turler, $ozet, $fragman, $resim, $cover, $video, $sure, $uzunluk, $sira);
		$say = 0;
		while($statement->fetch()) {
			$say++;	
			$data .= ($say > 1 ? ',' : '');
			$data .= '{"badge": "{txt:msx-white:'.$dil.' - }{txt:orange:'.$imdb.'}",';
			$kalan = "";
			$pcolor = "";
			$progress = 0.0;
			switch ($sira) {
				case 0:
					$data .= '"tagColor": "msx-yellow","tag": "DEVAM",';
					$progress = $sure / $uzunluk;
					$ks = (new DateTime('@0'))->diff(new DateTime('@'.($uzunluk - $sure)));
					$kalan = $ks->h > 0 ? '{txt:msx-yellow:'.$ks->h.' saat' : '';
					$kalan .= $ks->i > 0 ? ($kalan == '' ? '{txt:msx-yellow:' : ' ').$ks->i.' dakika' : '';
					$kalan .= $ks->s > 0 ? ($kalan == '' ? '{txt:msx-yellow:' : ' ').$ks->s.' saniye' : '';
					$kalan .= $kalan == '' ? '' : ' kaldı}';
					$pcolor = 'msx-yellow';
					break;
				case 2:
					$data .= '"tagColor": "msx-green","tag": "İZLEDİ",';
					$ks = (new DateTime('@0'))->diff(new DateTime('@'.($uzunluk - $sure)));
					$kalan = $ks->h > 0 ? '{txt:msx-green:'.$ks->h.' saat' : '';
					$kalan .= $ks->i > 0 ? ($kalan == '' ? '{txt:msx-green:' : ' ').$ks->i.' dakika' : '';
					$kalan .= $ks->s > 0 ? ($kalan == '' ? '{txt:msx-green:' : ' ').$ks->s.' saniye' : '';
					$kalan .= $kalan == '' ? '' : ' kaldı}';
					$pcolor = 'msx-green';
					if($uzunluk>0)
						$progress = $sure / $uzunluk;
					break;
			}
			$ozet = str_replace(array("\r\n", "\r", "\n"), "{br}", $ozet);
			$ozet = str_replace('"',"'",$ozet);
			$data .= '"image": "'.$msx.($resim == ""?'img/filmafis.png':$resim).'",';
			$data .= '"selection": {"background": "'.($cover == "" ? '' : $msx.$cover).'","action": "[update:content:overlay:ozet|update:content:overlay:kalan]","data": {"progressColor": "'.$pcolor.'","titleFooter": "'.$kalan.'","progress": '.$progress.',"text": "{col:msx-white}{txt:orange:Ad: }'.$ad.($orjad == $ad || $orjad == '' ? '' : '{br}{txt:orange:Orj Ad: }'.$orjad).'{br}{txt:orange:Yıl - Tür: }'.$yil.' - '.str_replace(',',", ",$turler).'{br}{txt:orange:Konu: }'.$ozet.'"}},';
			$data .= '"action": "execute:user:'.$msx.'ayrinti.php?islem=1&tip=f&yid='.$fragman.'&id='.$id.'&ad='.urlencode($ad).'&video='.$video.'"}';
		}
	}
	if($say == 0)
	{
		$data = '{"type": "list","extension": "'.$kadi.'","headline": "'.$baslik.'","template": {"type": "default","layout": "0,0,12,6"},"header": {"headline": "Filtrele","items": ['.$datafiltre;
		$data .= ']},"items": [{"headline": "{ico:error-outline} {txt:msx-white:Film bulunamadı}"}';
	}		
	$data .= ']}';
	mysqli_close($baglanti);
	echo $data;
?>