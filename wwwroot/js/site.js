$(document).ready(function () {
    setTimeout(function () {
        $(".alert-success").fadeOut("slow", function () {
            $(this).alert('close');
        });
    }, 5000);

    var current = location.pathname;
    $('.nav-link').each(function () {
        var $this = $(this);
        if ($this.attr('href') === current) {
            $this.addClass('active');
        }
    });

    $('a[href*="#"]').on('click', function (e) {
        e.preventDefault();
        $('html, body').animate(
            {
                scrollTop: $($(this).attr('href')).offset().top,
            },
            500,
            'linear'
        );
    });

    $(window).scroll(function () {
        var scrollToTopBtn = $('#scrollToTopBtn');
        if ($(this).scrollTop() > 300) {
            scrollToTopBtn.addClass('show');
        } else {
            scrollToTopBtn.removeClass('show');
        }
    });

    $('#scrollToTopBtn').click(function () {
        $('html, body').animate({ scrollTop: 0 }, '300');
        return false;
    });
});