
const menuBtn = document.getElementById('menu-btn');
const closeBtn = document.getElementById('close-btn');
const nav = document.querySelector('nav');
const discordIcon = document.getElementById('discord-icon');
const discordPopup = document.getElementById('discord-popup');
const closePopup = document.getElementById('close-popup')


menuBtn.addEventListener('click', () => {
    nav.classList.add('active');
    menuBtn.style.display = 'none'; 
    closeBtn.style.display = 'block'; 
});


closeBtn.addEventListener('click', () => {
    nav.classList.remove('active');
    menuBtn.style.display = 'block'; 
    closeBtn.style.display = 'none'; 
});

discordIcon.addEventListener('click', () => {
    event.preventDefault();
    discordPopup.style.display = 'block';
    const iconposition = discordIcon.getBoundingClientRect();
    const iconOffsetTop = discordIcon.offsetTop;
    discordPopup.style.left = `${iconposition.left}px`;
    discordPopup.style.top =  `${iconOffsetTop - discordPopup.offsetHeight + 16}px`;
});

closePopup.addEventListener('click', () => {
    discordPopup.style.display = 'none';
});

//prevents resizing
window.addEventListener('resize', () => {
    if (window.innerWidth > 700) { // For larger screens
        if (nav.classList.contains('active')) {
            nav.classList.remove('active');    
            closeBtn.style.display = 'none';   
            menuBtn.style.display = 'none';    
        } else { // Menu is not open
            menuBtn.style.display = 'none';    
            closeBtn.style.display = 'none';   
        }
    } else { // For smaller screens
        if (!nav.classList.contains('active')) { 
            menuBtn.style.display = 'block';   
            closeBtn.style.display = 'none';   
        } else { // Menu is open
            menuBtn.style.display = 'none';   
            closeBtn.style.display = 'block';  
        }
    }
});