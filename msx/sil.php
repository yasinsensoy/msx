<?php
	$header = apache_request_headers();
	if(isset($header["ad"]))
	{
		unlink($header["ad"]);
	}  
?>