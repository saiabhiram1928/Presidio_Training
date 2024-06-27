document.getElementById('hamburger').addEventListener('click', () => {
    document.getElementById('mobileMenu').classList.toggle('hidden');
});

const hero = document.getElementById("hero");
const about = document.getElementById("about");
const quotes = document.getElementById("quotes");

const navigateTo = (e,section) => {
    e.preventDefault();
    hero.classList.add('hidden');
    about.classList.add('hidden');
    quotes.classList.add('hidden');
    console.log(hero,about,quotes ,section);
    if (section === 'quotes') {
       
        fetchQuotes(1);
    }

    document.getElementById(section).classList.remove('hidden');
};


const getQueryParam = (param) => {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    return urlParams.get(param);
}

const quoteList = document.getElementById('quoteList');
const pagination = document.getElementById('pagination');

const fetchQuotes = async(page = 1, limit = 6) => {
    try {
        const response = await fetch(`https://dummyjson.com/quotes?limit=${limit}&skip=${(page - 1) * limit}`);
        const data = await response.json();

        displayQuotes(data.quotes);
        renderPagination(data.total, page, limit);
    } catch (error) {
        console.error('Error fetching quotes:', error);
    }
}


const displayQuotes = (quotes) => {
    quoteList.innerHTML = '';
    quotes.forEach((quote) => {
        const quoteCard = document.createElement('div');
        quoteCard.classList.add('p-2', 'w-full'); // Tailwind CSS classes for styling
        quoteCard.innerHTML = `
            <div class="h-full flex items-center border-gray-200 border p-4 rounded-lg">
                <div class="flex-grow">
                    <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="inline-block w-2 h-2 text-gray-400" viewBox="0 0 975.036 975.036">
                        <path d="M925.036 57.197h-304c-27.6 0-50 22.4-50 50v304c0 27.601 22.4 50 50 50h145.5c-1.9 79.601-20.4 143.3-55.4 191.2-27.6 37.8-69.399 69.1-125.3 93.8-25.7 11.3-36.8 41.7-24.8 67.101l36 76c11.6 24.399 40.3 35.1 65.1 24.399 66.2-28.6 122.101-64.8 167.7-108.8 55.601-53.7 93.7-114.3 114.3-181.9 20.601-67.6 30.9-159.8 30.9-276.8v-239c0-27.599-22.401-50-50-50zM106.036 913.497c65.4-28.5 121-64.699 166.9-108.6 56.1-53.7 94.4-114.1 115-181.2 20.6-67.1 30.899-159.6 30.899-277.5v-239c0-27.6-22.399-50-50-50h-304c-27.6 0-50 22.4-50 50v304c0 27.601 22.4 50 50 50h145.5c-1.9 79.601-20.4 143.3-55.4 191.2-27.6 37.8-69.4 69.1-125.3 93.8-25.7 11.3-36.8 41.7-24.8 67.101l35.9 75.8c11.601 24.399 40.501 35.2 65.301 24.399z"></path>
                    </svg>
                    <h2 class="text-white title-font font-medium">${quote.quote}</h2>
                    <p class="text-pink-300 text-right">-${quote.author}</p>
                </div>
            </div>
        `;
        quoteList.appendChild(quoteCard);
    });
}

const renderPagination = (totalQuotes, currentPage, quotesPerPage) => {
    pagination.innerHTML = '';
    const totalPages = Math.ceil(totalQuotes / quotesPerPage);

    
    const prevButton = document.createElement('button');
    prevButton.textContent = 'Previous';
    prevButton.classList.add('px-4', 'py-2', 'mx-2', 'bg-gray-700', 'hover:bg-gray-600', 'text-white', 'rounded');
    prevButton.addEventListener('click', () => {
        const prevPage = currentPage === 1 ? totalPages : currentPage - 1;
        fetchQuotes(prevPage, quotesPerPage);
    });
    pagination.appendChild(prevButton);


    const currentPageDisplay = document.createElement('span');
    currentPageDisplay.textContent = `Page ${currentPage} of ${totalPages}`;
    currentPageDisplay.classList.add('px-4', 'py-2', 'mx-2', 'text-gray-700');
    pagination.appendChild(currentPageDisplay);

    
    const nextButton = document.createElement('button');
    nextButton.textContent = 'Next';
    nextButton.classList.add('px-4', 'py-2', 'mx-2', 'bg-gray-700', 'hover:bg-gray-600', 'text-white', 'rounded');
    nextButton.addEventListener('click', () => {
        const nextPage = currentPage === totalPages ? 1 : currentPage + 1;
        fetchQuotes(nextPage, quotesPerPage);
    });
    pagination.appendChild(nextButton);
}

const section = getQueryParam('section') || 'home';
navigateTo(section);
