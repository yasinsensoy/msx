<?php
	if(!isset($_GET["islem"]) || !isset($_GET["kadi"]) || !isset($_GET["kid"]) || $_GET["islem"] != "1")
		exit();
	setcookie("kadi", $_GET["kadi"]);
	setcookie("kid", $_GET["kid"]);	
	include('db.php');
	include('cf.php');
	header('Content-Type: application/json');
	$data = '{"type": "list","extension": "{txt:msx-white:Giriş yapan: '.$_GET["kadi"].'}","pages": [{"items": [';
	$say = 0;
	$say1 = 0;
	$l = 0;
	$t = 0;
	$l1 = 0; 
	$filmler = array("Yerli","Yabancı");
	$diziler = array("Yerli","Yabancı");	
	$kanallar = array("Tümü");
	$statement = $baglanti->prepare("SELECT tur FROM kanal GROUP BY tur");
	$statement->execute();
	$statement->bind_result($tur);
	while($statement->fetch()) {
		$kanallar[] = $tur;
	}
	$degerler = array(array($filmler,"local-movies","Filmler"),array($diziler,"movie","Diziler"),array($kanallar,"live-tv","Kanallar"));
	foreach($degerler as $arr){
		$say += 1;
		$data .= ($say > 1 ? ',' : '');
		$data .= '{"type": "default","layout": "'.$l1.',0,3,3","icon": "'.$arr[1].'","iconSize": "large","label": "'.$arr[2].'","action": "panel:data","data": {"headline": "'.$arr[2].'","pages": [{"items": [';
		foreach($arr[0] as $ad){
			$say1 += 1;
			$data .= ($say1 > 1 ? ',' : '');
			$data .= '{"type": "default","layout": "'.$l.','.$t.',2,2","icon": "'.$arr[1].'","iconSize": "medium","alignment": "center","titleHeader": "{txt:msx-white:'.$ad.'}",';
			$data .= '"action": "'.($arr[2] == 'Filmler' ? 'content' : 'execute').':user:'.$msx.strtolower($arr[2]).'.php?islem=1&tur='.$ad.($arr[2] == 'Diziler' || $arr[2] == 'Filmler' ? '&sayfa=1&sgad='.$sgad.'&spad='.$spad.'&turler=Tümü&yil=Tümü':'').'"}';
			$l += 2;
			if($l == 8)
			{
				if($t == 4)
				{
					$t = 0;
					$say1 = 0;
					$data .= ']},{"items": [';
				}
				else
					$t += 2;
				$l = 0;
			}
		}
		$l = 0;
		$t = 0;
		$say1 = 0;
		$data .= ']}]}}';
		$l1 += 3;
	}
	$data .= ']}]}';
	echo $data;
?>