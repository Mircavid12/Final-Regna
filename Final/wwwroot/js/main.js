
$(document).ready(function () {
    let nav = document.querySelector("nav")

    $(window).scroll(function () {
        if ($(window).scrollTop() > 72) {
            nav.classList.add("nav-scroll");
            nav.style.padding = "16px 20px 13px 106px";
        }
         else {
            nav.classList.remove("nav-scroll");
            nav.style.padding = "23px 20px 20px 106px";
        }
    });

    $(".grid").isotope({
        itemSelector: ".portfolio-card",
        layotMode : "fitRows",
    });

    $(".menu ul li").click(function(){
        console.log("ss");
        $(".menu ul li").removeClass("active");
        $(this).addClass("active");
        var select = $(this).attr("data-filter");
        $(".grid").isotope({
            filter : select
        });
        return false
    });
})



window.onload = function () { document.querySelector(".preloader").style.display = "none"; }
// Facts counter
const counters = document.querySelectorAll('.counter');
const speed = 200;

counters.forEach(counter=>{
    const updateCount = () =>{
        const target = +counter.getAttribute('data-target');
        const count = +counter.innerText;
        
        const inc = target/speed;
        
        if(count<target){
            counter.innerText=Math.ceil(count+inc);
            setTimeout(updateCount,1);
            
        }
        else{
            count.innerText=target;
        }
    }
    updateCount();
});
// Facts Counter




// Canvas for Header
(function () {
	'use strict';
	
	var canvas,
      ctx,
      mousePos,
      points = [],
      maxDist = 200,
	  colour = "45,201,151";

	function init () {
		//Add on load scripts
		canvas = document.getElementById("canvas");
		ctx = canvas.getContext("2d");
		canvas.addEventListener("mousemove",function(evt){
			mousePos = getMousePos(canvas,evt);
		});
		resizeCanvas();
		generatePoints(80);
		pointFun();
		setInterval(pointFun,16);
		window.addEventListener('resize', resizeCanvas, false);
	}
	//Particle constructor
	function point () {
		this.x = (Math.random()*(canvas.width+maxDist))-(maxDist/2);
		this.y = (Math.random()*(canvas.height+maxDist))-(maxDist/2);
		this.vx = (Math.random()*1)-.5;
		this.vy = (Math.random()*1)-.5;
    this.dia = Math.random()*3+1;
		points.push(this);
	}
	//Point generator
	function generatePoints (amount) {
		var temp;
		for (var i = 0; i < amount; i++) {
			temp = new point();
		};
		console.log(points);
	}
	//Point drawer
	function draw (obj) {
		ctx.beginPath();
		ctx.fillStyle = "rgb("+colour+")";
		if(obj.dia){
      ctx.arc(obj.x,obj.y,obj.dia,0,2*Math.PI);
    }else{
      ctx.arc(obj.x,obj.y,2,0,2*Math.PI);
    }
		ctx.closePath();
		ctx.fill();
		//ctx.stroke();
	}
	//Updates point position values
	function update (obj) {
		obj.x += obj.vx;
		obj.y += obj.vy;
		if (obj.x > canvas.width+(maxDist/2)) {
			obj.x = -(maxDist/2);
		}
		else if (obj.xpos < -(maxDist/2)) {
			obj.x = canvas.width+(maxDist/2);
		}
		if (obj.y > canvas.height+(maxDist/2)) {
			obj.y = -(maxDist/2);
		}
		else if (obj.y < -(maxDist/2)) {
			obj.y = canvas.height+(maxDist/2);
		}
	}
	//
	function pointFun () {
		ctx.clearRect(0, 0, canvas.width, canvas.height);
		if (mousePos) {
			collision(mousePos,maxDist*2);
			draw(mousePos);
		}
		for (var i = 0; i < points.length; i++) {
			collision(points[i],maxDist);
      draw(points[i]);
			update(points[i]);
		};
	}

	function collision (obj,dist) {
		var temp;
		for (var i = 0; i < points.length; i++) {
			//Don't interact with self
			if (obj !== points[i]) {
				temp = Math.sqrt(Math.pow((obj.x - points[i].x),2) + Math.pow((obj.y - points[i].y),2));
				if (temp<dist) {
					ctx.beginPath();
					ctx.moveTo(obj.x, obj.y);
					ctx.strokeStyle = "rgba("+colour+","+.8*Math.pow((dist-temp)/dist,5)+")";
          ctx.moveTo(obj.x, obj.y);
					ctx.lineTo(points[i].x, points[i].y);
					ctx.closePath();
					ctx.stroke();
				};
			}
		};
	}

	function resizeCanvas() {
		canvas.width = window.innerWidth;
	canvas.height = window.innerHeight;
		pointFun();
	}

	function getMousePos(cvs, evt1) {
		var rect = cvs.getBoundingClientRect();
		return {
			x: evt1.clientX - rect.left,
			y: evt1.clientY - rect.top
		};
	}

	//Execute when DOM has loaded
	document.addEventListener('DOMContentLoaded',init,false);
})();
// Canvas for Header




// Login Register

/**
 * Variables
 */
const signupButton = document.getElementById('signup-button'),
    loginButton = document.getElementById('login-button'),
    userForms = document.getElementById('user_options-forms')

/**
 * Add event listener to the "Sign Up" button
 */
signupButton.addEventListener('click', () => {
  userForms.classList.remove('bounceRight')
  userForms.classList.add('bounceLeft')
}, false)

/**
 * Add event listener to the "Login" button
 */
loginButton.addEventListener('click', () => {
  userForms.classList.remove('bounceLeft')
  userForms.classList.add('bounceRight')
}, false)