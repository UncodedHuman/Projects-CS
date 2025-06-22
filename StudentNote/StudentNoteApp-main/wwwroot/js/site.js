// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
 // Define a threshold for the document's height in pixels.
 const HEIGHT_THRESHOLD = 2000; // Change this value as needed.

 function adjustBackground() {
   // Use document.body.scrollHeight or document.documentElement.scrollHeight for full page height.
   const pageHeight = Math.max(
     document.body.scrollHeight, 
     document.documentElement.scrollHeight
   );

   if (pageHeight > HEIGHT_THRESHOLD) {
     // If the page is longer than the threshold, remove the background image and set background to white.
    document.body.style.backgroundColor ="rgb(255, 250, 243)";
    document.body.style.backgroundImage = "none";

   } else {
     // Otherwise, restore the background image if needed.
     document.body.style.backgroundImage = 'url("https://thamesbritishschool.pl/app/uploads/sites/4/2023/03/2-5I3A1726.jpg")';
     document.body.style.backgroundColor = ""
   }
 }

 // Run the function once the page has loaded.
 window.addEventListener("load", adjustBackground);
 // Also adjust if the window is resized (if content reflows).
 window.addEventListener("resize", adjustBackground);