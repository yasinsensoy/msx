<?php
	$msx = "http://192.168.1.106:80/msx/";
	$kadi = isset($_COOKIE["kadi"]) ? '{txt:msx-white:Giriş yapan: '.$_COOKIE["kadi"].'}' : "";
	$sgad = isset($_COOKIE["sgad"]) ? $_COOKIE["sgad"] : "Eklenme (9-0)";
	$spad = isset($_COOKIE["spad"]) ? $_COOKIE["spad"] : "id DESC";
?>