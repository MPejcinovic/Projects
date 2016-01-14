<script>
		var definition = {smile:{title:"Smile",codes:[":)",":=)",":-)"]},"sad-smile":{title:"Sad Smile",codes:[":(",":=(",":-("]},"big-smile":{title:"Big Smile",codes:[":D",":=D",":-D",":d",":=d",":-d"]},cool:{title:"Cool",codes:["8)","8=)","8-)","B)","B=)","B-)","(cool)"]},wink:{title:"Wink",codes:[":o",":=o",":-o",":O",":=O",":-O"]},crying:{title:"Crying",codes:[";(",";-(",";=("]},sweating:{title:"Sweating",codes:["(sweat)","(:|"]},speechless:{title:"Speechless",codes:[":|",":=|",":-|"]},kiss:{title:"Kiss",codes:[":*",":=*",":-*"]},"tongue-out":{title:"Tongue Out",codes:[":P",":=P",":-P",":p",":=p",":-p"]},blush:{title:"Blush",codes:["(blush)",":$",":-$",":=$",':">']},wondering:{title:"Wondering",codes:[":^)"]},sleepy:{title:"Sleepy",codes:["|-)","I-)","I=)","(snooze)"]},dull:{title:"Dull",codes:["|(","|-(","|=("]},"in-love":{title:"In love",codes:["(inlove)"]},"evil-grin":{title:"Evil grin",codes:["]:)",">:)","(grin)"]},talking:{title:"Talking",codes:["(talk)"]},yawn:{title:"Yawn",codes:["(yawn)","|-()"]},puke:{title:"Puke",codes:["(puke)",":&",":-&",":=&"]},"doh!":{title:"Doh!",codes:["(doh)"]},angry:{title:"Angry",codes:[":@",":-@",":=@","x(","x-(","x=(","X(","X-(","X=("]},"it-wasnt-me":{title:"It wasn't me",codes:["(wasntme)"]},party:{title:"Party!!!",codes:["(party)"]},worried:{title:"Worried",codes:[":S",":-S",":=S",":s",":-s",":=s"]},mmm:{title:"Mmm...",codes:["(mm)"]},nerd:{title:"Nerd",codes:["8-|","B-|","8|","B|","8=|","B=|","(nerd)"]},"lips-sealed":{title:"Lips Sealed",codes:[":x",":-x",":X",":-X",":#",":-#",":=x",":=X",":=#"]},hi:{title:"Hi",codes:["(hi)"]},call:{title:"Call",codes:["(call)"]},devil:{title:"Devil",codes:["(devil)"]},angel:{title:"Angel",codes:["(angel)"]},envy:{title:"Envy",codes:["(envy)"]},wait:{title:"Wait",codes:["(wait)"]},bear:{title:"Bear",codes:["(bear)","(hug)"]},"make-up":{title:"Make-up",codes:["(makeup)","(kate)"]},"covered-laugh":{title:"Covered Laugh",codes:["(giggle)","(chuckle)"]},"clapping-hands":{title:"Clapping Hands",codes:["(clap)"]},thinking:{title:"Thinking",codes:["(think)",":?",":-?",":=?"]},bow:{title:"Bow",codes:["(bow)"]},rofl:{title:"Rolling on the floor laughing",codes:["(rofl)"]},whew:{title:"Whew",codes:["(whew)"]},happy:{title:"Happy",codes:["(happy)"]},smirking:{title:"Smirking",codes:["(smirk)"]},nodding:{title:"Nodding",codes:["(nod)"]},shaking:{title:"Shaking",codes:["(shake)"]},punch:{title:"Punch",codes:["(punch)"]},emo:{title:"Emo",codes:["(emo)"]},yes:{title:"Yes",codes:["(y)","(Y)","(ok)"]},no:{title:"No",codes:["(n)","(N)"]},handshake:{title:"Shaking Hands",codes:["(handshake)"]},skype:{title:"Skype",codes:["(skype)","(ss)"]},heart:{title:"Heart",codes:["(h)","<3","(H)","(l)","(L)"]},"broken-heart":{title:"Broken heart",codes:["(u)","(U)"]},mail:{title:"Mail",codes:["(e)","(m)"]},flower:{title:"Flower",codes:["(f)","(F)"]},rain:{title:"Rain",codes:["(rain)","(london)","(st)"]},sun:{title:"Sun",codes:["(sun)"]},time:{title:"Time",codes:["(o)","(O)","(time)"]},music:{title:"Music",codes:["(music)"]},movie:{title:"Movie",codes:["(~)","(film)","(movie)"]},phone:{title:"Phone",codes:["(mp)","(ph)"]},coffee:{title:"Coffee",codes:["(coffee)"]},pizza:{title:"Pizza",codes:["(pizza)","(pi)"]},cash:{title:"Cash",codes:["(cash)","(mo)","($)"]},muscle:{title:"Muscle",codes:["(muscle)","(flex)"]},cake:{title:"Cake",codes:["(^)","(cake)"]},beer:{title:"Beer",codes:["(beer)"]},drink:{title:"Drink",codes:["(d)","(D)"]},dance:{title:"Dance",codes:["(dance)","\\o/","\\:D/","\\:d/"]},ninja:{title:"Ninja",codes:["(ninja)"]},star:{title:"Star",codes:["(*)"]},mooning:{title:"Mooning",codes:["(mooning)"]},finger:{title:"Finger",codes:["(finger)"]},bandit:{title:"Bandit",codes:["(bandit)"]},drunk:{title:"Drunk",codes:["(drunk)"]},smoking:{title:"Smoking",codes:["(smoking)","(smoke)","(ci)"]},toivo:{title:"Toivo",codes:["(toivo)"]},rock:{title:"Rock",codes:["(rock)"]},headbang:{title:"Headbang",codes:["(headbang)","(banghead)"]},bug:{title:"Bug",codes:["(bug)"]},fubar:{title:"Fubar",codes:["(fubar)"]},poolparty:{title:"Poolparty",codes:["(poolparty)"]},swearing:{title:"Swearing",codes:["(swear)"]},tmi:{title:"TMI",codes:["(tmi)"]},heidy:{title:"Heidy",codes:["(heidy)"]},myspace:{title:"MySpace",codes:["(MySpace)"]},malthe:{title:"Malthe",codes:["(malthe)"]},tauri:{title:"Tauri",codes:["(tauri)"]},priidu:{title:"Priidu",codes:["(priidu)"]}};
		var snowmax=70
		var snowcolor=new Array("#aaaacc","#ddddFF","#ccccDD")
		var snowtype=new Array("Arial Black","Arial Narrow","Times","Comic Sans MS")
		var snowletter="*"
		var sinkspeed=0.5
		var snowmaxsize=30
		var snowminsize=10
		var snowingzone=1

		var snow=new Array()
		var marginbottom
		var marginright
		var timer
		var i_snow=0
		var x_mv=new Array();
		var crds=new Array();
		var lftrght=new Array();
		var browserinfos=navigator.userAgent 
		var ie5=document.all&&document.getElementById&&!browserinfos.match(/Opera/)
		var ns6=document.getElementById&&!document.all
		var opera=browserinfos.match(/Opera/)  
		var browserok=ie5||ns6||opera

		function randommaker(range) {		
			rand=Math.floor(range*Math.random())
			return rand
		}

		function initsnow() {
			if (ie5 || opera) {
				marginbottom = document.body.clientHeight
				marginright = document.body.clientWidth
			}
			else if (ns6) {
				marginbottom = window.innerHeight
				marginright = window.innerWidth
			}
			var snowsizerange=snowmaxsize-snowminsize
			for (i=0;i<=snowmax;i++) {
				crds[i] = 0;                      
				lftrght[i] = Math.random()*15;         
				x_mv[i] = 0.03 + Math.random()/10;
				snow[i]=document.getElementById("s"+i)
				snow[i].style.fontFamily=snowtype[randommaker(snowtype.length)]
				snow[i].size=randommaker(snowsizerange)+snowminsize
				snow[i].style.fontSize=snow[i].size
				snow[i].style.color=snowcolor[randommaker(snowcolor.length)]
				snow[i].sink=sinkspeed*snow[i].size/5
				if (snowingzone==1) {snow[i].posx=randommaker(marginright-snow[i].size)}
				if (snowingzone==2) {snow[i].posx=randommaker(marginright/2-snow[i].size)}
				if (snowingzone==3) {snow[i].posx=randommaker(marginright/2-snow[i].size)+marginright/4}
				if (snowingzone==4) {snow[i].posx=randommaker(marginright/2-snow[i].size)+marginright/2}
				snow[i].posy=randommaker(2*marginbottom-marginbottom-2*snow[i].size)
				snow[i].style.left=snow[i].posx
				snow[i].style.top=snow[i].posy
			}
			movesnow()
		}

		function movesnow() {
			for (i=0;i<=snowmax;i++) {
				crds[i] += x_mv[i];
				snow[i].posy+=snow[i].sink
				snow[i].style.left=snow[i].posx+lftrght[i]*Math.sin(crds[i]);
				snow[i].style.top=snow[i].posy
				
				if (snow[i].posy>=marginbottom-2*snow[i].size || parseInt(snow[i].style.left)>(marginright-3*lftrght[i])){
					if (snowingzone==1) {snow[i].posx=randommaker(marginright-snow[i].size)}
					if (snowingzone==2) {snow[i].posx=randommaker(marginright/2-snow[i].size)}
					if (snowingzone==3) {snow[i].posx=randommaker(marginright/2-snow[i].size)+marginright/4}
					if (snowingzone==4) {snow[i].posx=randommaker(marginright/2-snow[i].size)+marginright/2}
					snow[i].posy=0
				}
			}
			var timer=setTimeout("movesnow()",50)
		}

		for (i=0;i<=snowmax;i++) {
			document.write("<span id='s"+i+"' style='position:absolute;top:-"+snowmaxsize+"'>"+snowletter+"</span>")
		}
		if (browserok) {
			window.onload=initsnow
		}
		</script>

<?php
include('includes/header.php');
include_once 'db.php';
include_once 'common.php'; 
?>
<html>
  <head>
  </head>
  <body>
    <form class="form form-horizontal" action="analiza.php" method="post">
       <input type="hidden" name="action" value="analiziraj"> 
       <h4 class="form-heading"><font color = "#FFFFFF">Unesite vremenski period za provedbu analize:</font></h4>
        
       <div class="form_group col-lg-3">
          <input type="text" name="donjaGranica" class="form-control" placeholder="Donja granica" autofocus>
       </div>
        
       <div class="form_group col-lg-3">
          <input type="text" name="gornjaGranica" class="form-control" placeholder="Gornja granica" autofocus>
       </div> 
       <br>
       <br>
       <br>
       <h4><font color = "#FFFFFF">Odaberite granulaciju analize:</font></h4>
       <p>
       <label class="radio-inline">
         <input type="radio" name='granulacija' value='dan' ><font color = "#FFFFFF">Dan</font>
       </label>
       <br>
       <label class="radio-inline">
         <input type="radio" name='granulacija' value='sat' checked><font color = "#FFFFFF">Sat</font>
       </label>
       </p>
       <br>
      <button class="btn btn-lg btn-primary" type="submit">Analiziraj</button>
      
    </form>
    
<?php
$action ="";
extract($_POST);
extract($_GET);

if ( $action == "analiziraj" ) 
{     
  $poc = gmdate("Y-m-d",@strtotime($donjaGranica));
  $kraj = gmdate("Y-m-d",@strtotime($gornjaGranica));
  $lista[] = $poc;
  $current = $poc;
  while($current < $kraj){
    $current = gmdate("Y-m-d",@strtotime("+1 day", @strtotime($current)));
    $lista[] = $current;
  }
  $brojDana = count($lista);
  #echo $_POST['granulacija'];
  #if (isset($_POST['granulacija'])){
    if ($_POST['granulacija']=='dan'){
       $dodatak="";
       $zapis = "DISCARD TEMP;CREATE TEMP TABLE datum(dan date);";
       foreach($lista as $li){
        $zapis.="INSERT INTO datum VALUES ('$li');";
       }
       for($i = 0; $i < count($lista); $i++){
          $dodatak.=", dat$i  bigint";
       }
      $query = $zapis."SELECT * FROM crosstab ('SELECT DISTINCT upit,datum_unosa,COUNT(*) as brUpita FROM movies.upiti WHERE datum_unosa >= ''$donjaGranica'' AND datum_unosa <= ''$gornjaGranica'' GROUP BY datum_unosa, upit ORDER BY datum_unosa, upit','SELECT dan FROM datum ORDER BY dan') AS pivotTable(upit Char(100)".$dodatak.") ORDER BY upit";
      #echo $query;
      #$result = pg_exec($db, $query);
    }
    else{
      $query = "DISCARD TEMP;CREATE TEMP TABLE sat(rbrSat int);INSERT INTO sat VALUES (00);INSERT INTO sat VALUES (01);INSERT INTO sat VALUES (02);INSERT INTO sat VALUES (03);INSERT INTO sat VALUES (04);INSERT INTO sat VALUES (05);INSERT INTO sat VALUES (06);INSERT INTO sat VALUES (07);INSERT INTO sat VALUES (08);INSERT INTO sat VALUES (09);INSERT INTO sat VALUES (10);INSERT INTO sat VALUES (11);INSERT INTO sat VALUES (12);INSERT INTO sat VALUES (13);INSERT INTO sat VALUES (14);INSERT INTO sat VALUES (15);INSERT INTO sat VALUES (16);INSERT INTO sat VALUES (17);INSERT INTO sat VALUES (18);INSERT INTO sat VALUES (19);INSERT INTO sat VALUES (20);INSERT INTO sat VALUES (21);INSERT INTO sat VALUES (22);INSERT INTO sat VALUES (23);SELECT * FROM crosstab ('SELECT upit,EXTRACT(HOUR FROM vrijeme_unosa) as sat,COUNT(*) as brUpita FROM movies.upiti WHERE datum_unosa >= ''$donjaGranica'' AND datum_unosa <= ''$gornjaGranica'' GROUP BY sat, upit ORDER BY sat, upit','SELECT rbrSat FROM sat ORDER BY rbrSat') AS pivotTable(upit Char(100), s00_01 int, s01_02 int, s02_03 int, s03_04 int, s04_05 int, s05_06 int, s06_07 int, s07_08 int, s08_09 int, s09_10 int, s10_11 int, s11_12 int, s12_13 int, s13_14 int, s14_15 int, s15_16 int, s16_17 int, s17_18 int, s18_19 int, s19_20 int, s20_21 int, s21_22 int, s22_23 int, s23_24 int) ORDER BY upit";  
    }
  
      $result = pg_exec($db, $query);
      if ($query != "")
       {
               
               $Query=pg_query($db, $query);
               $brojRedaka = pg_numrows($Query);
               if (pg_numrows($Query)>0)
               {
                if ($_POST['granulacija']=='dan'){
                        echo "<table style=\"width:100%\">";
                        echo "<tr>";
                        echo "<th id=\"upit\"><font color = \"#FFFFFF\">upit character(100)</font></th>";
                        foreach($lista as $l){
                          echo "<th id=\"$l\"><font color = \"#FFFFFF\">".$l." bigint</font></th>";
                        }
                        echo "</tr>";
                        for ($i = 0; $i < $brojRedaka; $i++){
                          echo "<tr>";
                          for ($j = 0; $j < $brojDana+1; $j++){
                            $value = pg_fetch_result($Query, $i, $j);
                            if ($value == ''){
                                $value = '0';
                            }
                            echo "<td><font color = \"#FFFFFF\">$value</font></td>";
                        }
                          echo "</tr>";
                        }
                        echo "</table>";
                 }else{
                      echo "<table style=\"width:100%\">";
                        echo "<tr>";
                        echo "<th id=\"upit\"><font color = \"#FFFFFF\">upit character(100)</font></th>";
                        echo "<th id=\"jedan\"><font color = \"#FFFFFF\">00_01 bigint</font></th>";
                        echo "<th id=\"dva\"><font color = \"#FFFFFF\">01_02 bigint</font></th>";
                        echo "<th id=\"tri\"><font color = \"#FFFFFF\">02_03 bigint</font></th>";
                        echo "<th id=\"cetiri\"><font color = \"#FFFFFF\">03_04 bigint</font></th>";
                        echo "<th id=\"pet\"><font color = \"#FFFFFF\">04_05 bigint</font></th>";
                        echo "<th id=\"sest\"><font color = \"#FFFFFF\">05_06 bigint</font></th>";
                        echo "<th id=\"sedam\"><font color = \"#FFFFFF\">06_07 bigint</font></th>";
                        echo "<th id=\"osam\"><font color = \"#FFFFFF\">07_08 bigint</font></th>";
                        echo "<th id=\"devet\"><font color = \"#FFFFFF\">08_09 bigint</font></th>";
                        echo "<th id=\"deset\"><font color = \"#FFFFFF\">09_10 bigint</font></th>";
                        echo "<th id=\"jedanaest\"><font color = \"#FFFFFF\">10_11 bigint</font></th>";
                        echo "<th id=\"dvanaest\"><font color = \"#FFFFFF\">11_12 bigint</font></th>";
                        echo "<th id=\"trinaest\"><font color = \"#FFFFFF\">12_13 bigint</font></th>";
                        echo "<th id=\"cetrnaest\"><font color = \"#FFFFFF\">13_14 bigint</font></th>";
                        echo "<th id=\"petnaest\"><font color = \"#FFFFFF\">14_15 bigint</font></th>";
                        echo "<th id=\"sesnaest\"><font color = \"#FFFFFF\">15_16 bigint</font></th>";
                        echo "<th id=\"sedamnaest\"><font color = \"#FFFFFF\">16_17 bigint</font></th>";
                        echo "<th id=\"osamnaest\"><font color = \"#FFFFFF\">17_18 bigint</font></th>";
                        echo "<th id=\"devetnaest\"><font color = \"#FFFFFF\">18_19 bigint</font></th>";
                        echo "<th id=\"dvadeset\"><font color = \"#FFFFFF\">19_20 bigint</font></th>";
                        echo "<th id=\"dvadesetjedan\"><font color = \"#FFFFFF\">20_21 bigint</font></th>";
                        echo "<th id=\"dvadesetdva\"><font color = \"#FFFFFF\">21_22 bigint</font></th>";
                        echo "<th id=\"dvadesettri\"><font color = \"#FFFFFF\">22_23 bigint</font></th>";
                        echo "<th id=\"dvadesetcetiri\"><font color = \"#FFFFFF\">23_24 bigint</font></th>";
                        echo "</tr>";
                        for ($i = 0; $i < $brojRedaka; $i++){
                          echo "<tr>";
                          for ($j = 0; $j < 25; $j++){
                            $value = pg_fetch_result($Query, $i, $j);
                            if ($value == ''){
                                $value = '0';
                            }
                            echo "<td><font color = \"#FFFFFF\">$value</font></td>";
                        }
                          echo "</tr>";
                        }
                        echo "</table>";
                 }  
               } 
       }           
}

?>
