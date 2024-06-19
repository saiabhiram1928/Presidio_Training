document.addEventListener("DOMContentLoaded", function() {

    const createCard = (item) => {
      const card = document.createElement("div");
      card.className = "max-w-sm rounded overflow-hidden shadow-lg bg-white";
  
      const img = document.createElement("img");
      img.className = "w-full";
      img.src = item.thumbnail || `https://via.placeholder.com/150?text=Image+${item.id}`;
      img.alt = item.title;
  
      const cardBody = document.createElement("div");
      cardBody.className = "px-6 py-4";
  
      const cardTitle = document.createElement("div");
      cardTitle.className = "font-bold text-xl mb-2";
      cardTitle.textContent = item.title;
  
      const cardDescription = document.createElement("p");
      cardDescription.className = "text-gray-700 text-base";
      cardDescription.textContent = item.description;
  
      const cardPrice = document.createElement("p");
      cardPrice.className = "text-gray-900 text-lg font-bold";
      cardPrice.textContent = `$${item.price}`;
  
      cardBody.appendChild(cardTitle);
      cardBody.appendChild(cardDescription);
      cardBody.appendChild(cardPrice);
      card.appendChild(img);
      card.appendChild(cardBody);
  
      return card;
    }
  
    
    const injectCards = (data) => {
      const cardContainer = document.getElementById("card-container");
      data.forEach(item => {
        cardContainer.appendChild(createCard(item));
      });
    }
   fetch('https://dummyjson.com/products')
    .then(response => response.json())
    .then(data => {
     
      const products = data.products;
      injectCards(products);
    })
    .catch(error => alert('Error fetching data:', error));
  });
  