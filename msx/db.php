<?php
	$baglanti = @mysqli_connect("localhost", "root", "", "medyalar");
	switch(mysqli_connect_errno())
	{
		case 0:break;
		case 2002:die("Veritabanı sunucusu bulunamadı.");break;
		case 1044:die("Kullanıcı adı veya şifre hatalı.");break;
		case 1045:die("Kullanıcı adı veya şifre hatalı.");break;
		case 1049:die("Veritabanı bulunamadı.");break;		
		default:die(mysqli_connect_errno().'<br>'.mysqli_connect_error());break;
	}
	$baglanti->set_charset("utf8");
?>