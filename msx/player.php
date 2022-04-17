<?php
	$opts = array(
	'http'=>array(
		'method'=>"GET",
		'header'=>"User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36 OPR/70.0.3728.106\r\n"
	)
	);
	$context = stream_context_create($opts);
	$file = file_get_contents('https://www.filmmodu.org/get-source?movie_id='.$_GET["mid"].'&type=tr', false, $context);
	$kaliteler = "";
	if($file != '{"status":404}'){
		$arr = json_decode($file)->sources;
		usort($arr, function($a, $b){return $a->res < $b->res; });
		foreach($arr as $kal)
			$kaliteler .= ($kaliteler == "" ? '"' : ',"').$kal->label.'": "'.$kal->src.'"';
	}
?>
<!DOCTYPE html>
<html>
    <head>
        <title>HTML5 Video Plugin</title>
        <meta charset="UTF-8" />
        <meta name="author" content="Benjamin Zachey" />
        <meta name="contact" content="admin@benzac.de" />
        <meta name="copyright" content="Benjamin Zachey" />
        <script type="text/javascript" src="http://msx.benzac.de/js/tvx-plugin.min.js"></script>
        <script type="text/javascript">
			function Html5Player() {
				var player = null;
				var ready = false;
				var ended = false;
				var zaman  = 0;
				var iid = 0;
				var mid = 0;
				var tip = '';
				var kaliteler = {<?php echo $kaliteler; ?>};
				var kalite = "720p";
			
				var onReady = function() {
					if (player != null && !ready) {
						ready = true;
						TVXVideoPlugin.debug("Video hazır");						
						TVXVideoPlugin.setPosition(zaman);
						TVXVideoPlugin.applyPosition();
						TVXVideoPlugin.startPlayback(true);//Accelerated start
					}
				};
				var getErrorText = function(code) {
					if (code == 1) {
						return "Playback Aborted";
					} else if (code == 2) {
						return "Ağ Hatası";
					} else if (code == 3) {
						return "Video Çözmede Hata";
					} else if (code == 4) {
						return "Kaynak Desteklenmiyor.";
					}
					return "Bilinmeyen Hata";
				};
				var getErrorMessage = function(code, message) {
					var msg = code + ": " + getErrorText(code);
					if (TVXTools.isFullStr(message)) {
						msg += ": " + message;
					}
					return msg;
				};
				var onError = function() {
					if (player != null && player.error != null) {
						TVXVideoPlugin.error("Hata: " + getErrorMessage(player.error.code, player.error.message));
					}
				};				
				var onEnded = function() {
					if (!ended) {
						ended = true;
						TVXVideoPlugin.debug("Video durdu");
						TVXVideoPlugin.stopPlayback();
					}
				};
				var ontimeupdate = function() {
					if (player != null && zaman + 5 < player.currentTime) {						
						zaman = parseInt(player.currentTime);
						var uzunluk = parseInt(player.duration);
						if(zaman == uzunluk)
							return;
						var xhttp = new XMLHttpRequest();
						xhttp.onreadystatechange = function() {
							if (this.readyState == 4) {
								if (this.status == 200 && this.getResponseHeader("iid") != null)
									iid = this.getResponseHeader("iid");
							}
						};
						xhttp.open("POST", "sureguncelle.php", true);
						xhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
						xhttp.send("sure="+zaman+"&tsure="+uzunluk+"&iid="+iid+"&mid="+mid+"&tip="+tip);
					}
				};
				this.init = function() {					
					player = document.getElementById("player");					
					player.addEventListener("canplay", onReady);
					player.addEventListener("error", onError);
					player.addEventListener("ended", onEnded);
					player.addEventListener("timeupdate", ontimeupdate);
				};
				this.ready = function() {
					if (player != null) {
						TVXVideoPlugin.debug("Video plugin ready");
						iid = TVXServices.urlParams.get("iid");
						mid = TVXServices.urlParams.get("mid");
						tip = TVXServices.urlParams.get("tip");
						var sure = TVXServices.urlParams.get("bz");
						zaman = sure < 0 ? 0 : --sure;
						var url = TVXServices.urlParams.get("url");
						if(TVXTools.isHttpUrl(url)) {
							player.src = url;
							player.load();
						} else {
							var keys = Object.keys(kaliteler);
							var len = keys.length;
							if(len > 0) {
								
								TVXVideoPlugin.executeAction("player:button:content:enable");
								if(kaliteler[kalite] == null)
									kalite = keys[len - 1];
								videoyukle();
							}
							else
								TVXVideoPlugin.error("Kaliteler yüklenemedi.");
						}
					} else
						TVXVideoPlugin.error("Video player is not initialized");
				};
				var videoyukle = function() {
					ready = false;
					player.src = kaliteler[kalite];
					player.load();					
					TVXVideoPlugin.executeAction("[player:label:extension:{txt:msx-red:"+kalite+"}|player:show]");
				};
				this.handleData = function(data) {
					if (data.data.kalite != null){
						kalite = data.data.kalite;
						videoyukle();
					}
				};
				this.handleRequest = function(dataId, data, callback) {
					if (dataId == "kalite") 
						callback(createPanel());
					else
						callback();
				};
				var createPanel = function() {
					var items = "";
					for(var key in kaliteler) 
						items += (items == "" ? "" : ",")+'{"label": "'+key+'",'+(key == kalite ? '"focus": true,"extensionIcon": "check",' : '')+'"action": "player:commit","data": {"kalite": "'+key+'"}}';
					var ts = '{"cache": false,"headline": "Kalite Seç","type": "list","template": {"type": "control", "layout": "0,0,8,1"},"items": ['+items+']}';
					return JSON.parse(ts);;
				};
				this.dispose = function() {
					if (player != null) {
						player.removeEventListener("canplay", onReady);
						player.removeEventListener("error", onError);
						player.removeEventListener("ended", onEnded);
						player.removeEventListener("timeupdate", ontimeupdate);
						player = null;
					}
				};
				this.play = function() {
					if (player != null) {
						player.play();
					}
				};
				this.pause = function() {
					if (player != null) {
						player.pause();
					}
				};
				this.stop = function() {
					if (player != null) {
						player.pause();
					}
				};
				this.getDuration = function() {
					if (player != null) {
						return player.duration;
					}
					return 0;
				};
				this.getPosition = function() {
					if (player != null) {
						return player.currentTime;
					}
					return 0;
				};
				this.setPosition = function(position) {
					if (player != null) {
						player.currentTime = position;
					}
				};
				this.setVolume = function(volume) {
					if (player != null) {
						player.volume = volume;
					}
				};
				this.getVolume = function() {
					if (player != null) {
						return player.volume;
					}
					return 100;
				};
				this.setMuted = function(muted) {
					if (player != null) {
						player.muted = muted;
					}
				};
				this.isMuted = function() {
					if (player != null) {
						return player.muted;
					}
					return false;
				};
				this.getSpeed = function() {
					if (player != null) {
						return player.playbackRate;
					}
					return 1;
				};
				this.setSpeed = function(speed) {
					if (player != null) {
						player.playbackRate = speed;
					}
				};
				this.setSize = function(width, height) {
					if (player != null) {
						player.width = width;
						player.height = height;
					}
				};
				this.getUpdateData = function() {
					return {
						position: this.getPosition(),
						duration: this.getDuration(),
						speed: this.getSpeed()
					};
				};
			}

			window.onload = function() {
				TVXVideoPlugin.setupPlayer(new Html5Player());
				TVXVideoPlugin.init();
			};
		</script>
		<style type="text/css">
			#player {
				position: fixed; right: 0; bottom: 0;
				min-width: 100%; min-height: 100%;
				width: 100%; height: 100%; z-index: -100;
				background-size: cover;
			}
		</style>
    </head>
    <body>
        <video id="player" playsinline></video>
    </body>
</html>