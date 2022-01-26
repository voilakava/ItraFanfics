$(document).ready(function () {
    $('.fanfic-name-link').hover(function () {
        console.log('работает ховер');
        $(this).prev().toggleClass('fanfic-name-link-prev');
        $(this).next().toggleClass('fanfic-name-link-prev');
    });
})