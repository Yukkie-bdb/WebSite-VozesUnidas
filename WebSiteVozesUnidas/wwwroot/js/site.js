// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function trocarElementos(categoria, btn) {
    // Hide all tab contents
    var tabcontents = document.querySelectorAll('.tabcontent');
    tabcontents.forEach(function (tab) {
        tab.style.display = 'none'; // Hide each tab content
    });

    console.log('Selected category:', categoria);
    // Show the current tab content based on the clicked category
    var currentTab = document.getElementById(categoria);
    if (currentTab) {
        currentTab.style.display = 'block'; // Show the relevant tab content
    } else {
        console.error('No tab content found for category:', categoria); // Log error if not found
    }

    // Remove 'active' class from all buttons (if you use a class to highlight active button)
    var tablinks = document.querySelectorAll('.tablink');
    tablinks.forEach(function (link) {
        link.classList.remove('active');
    });

    // Add 'active' class to the clicked button (if you use a class to highlight active button)
    if (btn) {
        btn.classList.add('active');
    }
}

const images = [
    { src: 'img/jean.jpg', name: 'CEO', description: 'renato augusto' },
    { src: 'img/luis.jpg', name: 'MESTRE DO MAR', description: 'renato teixeira' },
    { src: 'img/henrique.webp', name: 'JOGADOR', description: 'ronaldo' },
    { src: 'img/erick.jpg', name: 'PONTA', description: 'renan' },
    { src: 'img/pessoa03.jpg', name: 'ESQUERDA', description: 'lula' }

];

let currentImageIndex = 0;
const imageElement = document.getElementById('carouselImage');
const prevImageElement = document.getElementById('prevImage');
const nextImageElement = document.getElementById('nextImage');
const imageNameElement = document.getElementById('imageName');
const imageDescriptionElement = document.getElementById('imageDescription');

function showImage(index) {
    const prevIndex = (index - 1 + images.length) % images.length;
    const nextIndex = (index + 1) % images.length;

    imageElement.src = images[index].src;
    prevImageElement.src = images[prevIndex].src;
    nextImageElement.src = images[nextIndex].src;
    imageNameElement.textContent = images[index].name;
    imageDescriptionElement.textContent = images[index].description;
}

function nextImage() {
    currentImageIndex = (currentImageIndex + 1) % images.length;
    showImage(currentImageIndex);
}

function prevImage() {
    currentImageIndex = (currentImageIndex - 1 + images.length) % images.length;
    showImage(currentImageIndex);
}

document.addEventListener("DOMContentLoaded", function () {
    showImage(currentImageIndex);
});



function openModal() {
    document.getElementById("myModal").style.display = "flex";
}

function closeModal() {
    document.getElementById("myModal").style.display = "none";
}

function flipCard(cardElement) {
    cardElement.querySelector('.card-inner').classList.toggle('is-flipped');
}




