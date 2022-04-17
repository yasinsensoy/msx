<?php
	if(!isset($_GET["islem"]) || !isset($_GET["tip"]) || !isset($_GET["id"]) || !isset($_GET["yid"]) || !isset($_GET["ad"]) || !isset($_GET["video"]) || $_GET["islem"] != "1")
		exit();
	include('db.php');
	include('cf.php');
	header('Content-Type: application/json');
	$data = '{"type": "list","headline": "'.$_GET["ad"].'","template": {"type": "default","layout": "0,0,4,1"},"items": [';
	$statement = $baglanti->prepare("SELECT id,izle,sure FROM izleme WHERE tip='".$_GET["tip"]."' AND kid=".$_COOKIE["kid"]." AND mid=".$_GET["id"]);
	$statement->execute();
	$statement->bind_result($id, $izle, $sure);
	$statement->fetch();
	$var = isset($izle) && $izle;
	$data .= '{"label": "{ico:play-circle-outline} {txt:msx-white:İzle}",';
	$data .= '"color": "msx-blue",';
	$data .= '"playerLabel": "'.$_GET["ad"].'",';
	$data .= '"properties": {"button:content:icon": "hd","button:content:action": "[player:pause|release:panel|panel:request:player:kalite]","progress:color": "msx-red","button:prev:enable": "false","button:next:enable": "false","button:content:enable": "false","trigger:complete": "player:stop","trigger:stop": "reload:content","trigger:background": "player:stop"},';
	$data .= '"action": "video:plugin:'.$msx.'player.php?tip='.$_GET["tip"].'&mid='.$_GET["id"].'&iid='.(isset($id) ? $id : 0).'&bz='.(isset($sure) ? $sure : 0).'&url='.$_GET["video"].'"},';
	$data .= '{"label": "{ico:'.($var ? 'remove' : 'add').'-circle-outline} {txt:msx-white:'.($var ? 'İzlediklerimden Çıkar' : 'İzlediklerime Ekle').'}",';
	$data .= '"color": "msx-'.($var ? 'red' : 'green').'",';
	$data .= '"action": "execute:'.$msx.'izleme.php?islem=1&izle='.$izle.'&tur='.($var ? 'c' : (isset($izle) && !$izle ? 'g' : 'e')).'&tip='.$_GET["tip"].'&kid='.$_COOKIE["kid"].'&mid='.$_GET["id"].'"}';
	if($_GET["yid"] != "")
	{
		$data .= ',{"label": "{ico:live-tv} {txt:msx-white:Fragman}",';
		$data .= '"color": "msx-red",';
		$data .= '"playerLabel": "'.$_GET["ad"].' Fragman",';
		$v = substr($_GET["yid"],0,2)=="v:";
		$data .= '"properties": {"button:content:enable": "false","progress:color": "msx-red","button:prev:enable": "false","button:next:enable": "false","trigger:complete": "player:stop","trigger:background": "player:stop"},';
		$data .= '"action": "video:plugin:http://msx.benzac.de/plugins/'.($v ? 'vimeo' : 'youtube').'.html?id='.($v ? str_replace('v:','',$_GET["yid"]) : $_GET["yid"]).'"}';
	}	
	if($sure > 0)
	{
		$data .= ',{"label": "{ico:clear} {txt:msx-white:İzleme Geçmişini Sıfırla}",';
		$data .= '"color": "msx-yellow",';
		$data .= '"action": "execute:'.$msx.'sifirla.php?islem=1&tip='.$_GET["tip"].'&kid='.$_COOKIE["kid"].'&mid='.$_GET["id"].'"}';
	}
	$data .= ']}';
	mysqli_close($baglanti);
	echo '{"response": {"status": 200,"text": "OK","message": null,"data": {"action": "panel:data","data": '.$data.'}}}';
?>