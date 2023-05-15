

//////////////TypeScript Animation//////////////

// get the element for typeScript
var typeScript = document.getElementById('typeScript');

const emploi = ["front-end", "c#", "unity"]; 
const type = "Je suis développeur ";

 
//////////////Cursor Animation//////////////

// get the cursor for animate it
 (() => { 

    const cursor = document.querySelector('.cursor');
 
    document.addEventListener('mousemove', e => {
       cursor.setAttribute('style', `top:  ${e.pageY - 25}px; left: ${e.pageX - 25}px;`);
    });
 
    document.addEventListener('click', () => { 
       console.log("%c Click...!!!", "font-size: 20px; color:mediumspringgreen;");
 
       cursor.classList.add('cursor--expand');
       console.log(cursor.classList);
    
       setTimeout(() => {
          cursor.classList.remove('cursor--expand');
       }, 500);
    });
 })();
   
// use the typeScript object to  do the animation of typeScript
var typed = new Typed(typeScript, {
    strings :["erreur" ,`${type} ${emploi[0]}`, `${type} ${emploi[1]}`, `${type} ${emploi[2]}`],
    typeSpeed: 150,
    backspeed: 450,
    loop: true
});



//////////////Title Animation//////////////

// Get the title for animate it 
var textWrapper = document.querySelector('.title_name');
textWrapper.innerHTML = textWrapper.textContent.replace(/\S/g, "<span class='letter'>$&</span>");

//animate the title
anime.timeline({loop: true})
  .add({
    targets: '.title_name .letter',
    scale: [4,1],
    opacity: [0,1],
    translateZ: 0,
    easing: "easeOutExpo",
    duration: 950,
    delay: (el, i) => 70*i
  }).add({
    targets: '.ml2',
    opacity: 0,
    duration: 1000,
    easing: "easeOutExpo",
    delay: 1000
  });


    