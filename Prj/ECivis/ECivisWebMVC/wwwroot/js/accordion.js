    function toggleIcon(e) {
 
        $(e.target)
 
            .prev('.accordion-heading')
 
            .find(".short-full")
 
            .toggleClass('glyphicon-plus glyphicon-minus');
 
    }
 
    $('.accordion-group').on('hidden.bs.collapse', toggleIcon);
 
    $('.accordion-group').on('shown.bs.collapse', toggleIcon)