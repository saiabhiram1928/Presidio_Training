document.getElementById('hamburger').addEventListener('click', () => {
    document.getElementById('mobileMenu').classList.toggle('hidden');
});
const header =document.getElementById("header");
const hero = document.getElementById("hero")
const quotes = document.getElementById("quotes");
hero.classList.remove('hidden');
quotes.classList.add('hidden');
const QuotesClick = (e)=>{
    e.preventDefault();
    console.log("hoo");
    hero.classList.add('hidden');
    quotes.classList.remove('hidden');
}