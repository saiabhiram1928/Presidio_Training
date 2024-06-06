window.onload=function(){
    const education = document.querySelector(".education");
const edu = document.querySelector(".edu");

   education.addEventListener("click",function(){
    
        edu.classList.toggle("animate__heartBeat");
     
} ,false);
const skills = document.querySelector(".skills");
const sk = document.querySelector(".sk");

skills.addEventListener("click",function(){
    
        sk.classList.toggle("animate__heartBeat");
     
} ,false);
}