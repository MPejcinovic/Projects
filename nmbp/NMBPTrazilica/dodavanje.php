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

      <form class="form form-horizontal" action="dodavanje.php" method="post">
        <input type="hidden" name="action" value="dodaj"> 
        <h2 class="form-heading"></h2>
        
        <div class="form_group col-lg-8">
          <input type="text" name="naziv" class="form-control" placeholder="Naziv" autofocus>
        </div>
        
        <div class="form_group col-lg-8">
          <input type="text" name="redatelj" class="form-control" placeholder="Redatelj" autofocus>
        </div>
        
        <div class="form_group col-lg-8">
          <input type="text" name="radnja" class="form-control" placeholder="Radnja" autofocus>
        </div>
        
        <div class="form_group col-lg-8">
          <input type="text" name="zanr" class="form-control" placeholder="Zanr" autofocus>
        </div>
        
        <div class="form_group col-lg-8">
          <input type="text" name="vrijeme_trajanja" class="form-control" placeholder="Vrijeme trajanja" autofocus>
        </div>
        
        <div class="form_group col-lg-8">
          <input type="text" name="u_boji" class="form-control" placeholder="Boja" autofocus>
        </div>
        
        <div class="form_group col-lg-8">
          <input type="text" name="glavni_glumac" class="form-control" placeholder="Glavni glumac" autofocus>
        </div>
        
          <button class="btn btn-lg btn-primary" type="submit">Add</button>
      </form>

<?php
 
$action ="";
extract($_POST);
extract($_GET);

if ( $action == "dodaj" ) 
{
  echo "<div class='col-lg-8'><font color = '#FFFFFF'><br>Dodali ste novi zapis u bazu Trazilica:<p><i>$naziv</br></font></i></p></div>";
  $query = "INSERT INTO movies.filmovi(naziv, redatelj, radnja, zanr, vrijeme_trajanja, datum_unosa, vrijeme_unosa, u_boji, glavni_glumac, naziv_ts) VALUES('$naziv', '$redatelj', '$radnja', '$zanr', '$vrijeme_trajanja', now(), now(), '$u_boji', '$glavni_glumac', to_tsvector('english','$naziv'))";  
  $result = pg_exec($db, $query);
}

?>