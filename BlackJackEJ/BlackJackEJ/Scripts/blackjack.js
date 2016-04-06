var deck_id = 0;
var player_points = 0;
var dealer_points = 0;
var time_play = 0;
var dealer_play = 0;
var cartas_dealer = [];
var cartas_player = [];
$(document).ready(function () {
    $(".deck").hide();
    $(".player").hide();
    $(".dealer").hide();
    $(".player-title").hide();
    $(".dealer-title").hide();
    $(".loading").hide();
    $(".message-winner").hide();
    get_reporte();
    
    $(".btn-play").on("click", function () {
        create_deck();
    });

    $(".btn-deal").on("click", function () {
        time_play++;
        get_card_player(deck_id);
    });

    $(".btn-next").on("click", function () {
        time_play++;
        dealer_play ++;
        get_card_dealer(deck_id, 2);
    });

    $(".btn-ok").on("click", function () {
        window.location.href = "/";
    });

    $(".btn-deck").on("click", function () {
        rotar_baraja();
    });

    $(document).ajaxStart(function () {
        $(".btn-play").hide();
        $(".loading").show();
    });
});

function create_deck() {

    $.ajax({
        type: "POST",
        url: "/api/baraja"
    }).done(function (data) {
        $(".loading").remove();
        $(".deck").show();
        $(".player").show();
        $(".dealer").show();
        $(".player-title").show();
        $(".dealer-title").show();
        $(".navbar-nav").append('<li class="salir"><a href="/">Salir del Juego</a></li>');
        
        deck_id = data.Id;
        get_card_player(deck_id);
        get_card_player(deck_id);
        get_card_dealer(deck_id, 1);
        get_card_dealer(deck_id, 1);
    });
}

function get_card_player(deck_id) {
    $.get("/api/baraja/" + deck_id, function (data) {      
        $(".player").append('<img class="image-card" src="' + data.Imagen + '" />');
        var valor = data.Valor;
        var nombre = data.Nombre;
        calc_points_player(valor, nombre);
    });
}

function get_card_dealer(deck_id, type) {
    if (player_points < dealer_points && type == 2) {
        $(".message-winner").show();
        $(".deck").hide();
        $(".player-title").hide();
        $(".dealer-title").hide();
        $(".message-label").html("Gana el Dealer!!");
        $(".message-player").html("Jugador: " + player_points + " puntos");
        $(".message-dealer").html("Dealer: " + dealer_points + " puntos");
        insert_ganador(2);
    } else if (player_points == dealer_points && type == 2) {
        $(".message-winner").show();
        $(".deck").hide();
        $(".player-title").hide();
        $(".dealer-title").hide();
        $(".message-label").html("Empates!!");
        $(".message-player").html("Jugador: " + player_points + " puntos");
        $(".message-dealer").html("Dealer: " + dealer_points + " puntos");
        insert_ganador(3);
    } else {
        $.get("/api/baraja/" + deck_id, function (data) {
            $(".dealer").append('<img class="image-card" src="' + data.Imagen + '" />');
            var valor = data.Valor;
            var nombre = data.Nombre;
            calc_points_dealer(valor, nombre);
        });
    }
}

function calc_points_player(numero, nombre) {
    if (nombre == "AC" || nombre == "AD" || nombre == "AP" || nombre == "AT") {
        var test_player_point = player_points + numero;
        if (test_player_point > 21) {
            player_points = player_points + 1;
            $(".player-points").html("Jugador:  " + player_points + " puntos");
            get_ganador(player_points, dealer_points);
        }
        else {
            cartas_player.push(nombre);
            player_points = player_points + numero;
            $(".player-points").html("Jugador:  " + player_points + " puntos");
            get_ganador(player_points, dealer_points);
        }
    } else {
        var test_points_player = player_points + numero;
        if (test_points_player > 21) {
            for (index = 0; index < cartas_player.length; index++) {
                if (cartas_player[index] == "AC" || cartas_player[index] == "AD" || cartas_player[index] == "AP" || cartas_player[index] == "AT") {
                    player_points = player_points - 10;
                    cartas_player.splice(index, 1);
                    break;
                }
            }
        }
        
        cartas_player.push(nombre);
        player_points = player_points + numero;
        $(".player-points").html("Jugador:  " + player_points + " puntos");
        get_ganador(player_points, dealer_points);
    }
}

function calc_points_dealer(numero, nombre) {
    
    if (nombre == "AC" || nombre == "AD" || nombre == "AP" || nombre == "AT") {
        var test_dealer_point = dealer_points + numero;
        if (test_dealer_point > 21) {
            dealer_points = dealer_points + 1;
            $(".dealer-points").html("Dealer:  " + dealer_points + " puntos");
            get_ganador(player_points, dealer_points);
        }
        else {
            cartas_dealer.push(nombre);
            dealer_points = dealer_points + numero;
            $(".dealer-points").html("Dealer:  " + dealer_points + " puntos");
            get_ganador(player_points, dealer_points);
        }
    } else {
        var test_points_dealer = dealer_points + numero;
        if (test_points_dealer > 21) {
            for (index = 0; index < cartas_dealer.length; index++) {
                if (cartas_dealer[index] == "AC" || cartas_dealer[index] == "AD" || cartas_dealer[index] == "AP" || cartas_dealer[index] == "AT") {
                    dealer_points = dealer_points - 10;
                    cartas_dealer.splice(index, 1);
                    break;
                }
            }
        }
        cartas_dealer.push(nombre);
        dealer_points = dealer_points + numero;
        $(".dealer-points").html("Dealer:  " + dealer_points + " puntos");
        get_ganador(player_points, dealer_points);
    }
}

function get_ganador(player_points, dealer_points) {
    $.get("/api/juego/" + player_points + "/" + dealer_points, function (data) {    
        if (data == 1 && time_play == 0) {
            $(".message-winner").show();
            $(".deck").hide();
            $(".player-title").hide();
            $(".dealer-title").hide();
            $(".message-label").html("Black Jack!! Gana el Jugador");
            $(".message-player").html("Jugador: " + player_points + " puntos");
            $(".message-dealer").html("Dealer: " + dealer_points + " puntos");
            insert_ganador(1);
        } else if (data == 2 && time_play == 0) {
            $(".message-winner").show();
            $(".deck").hide();
            $(".player-title").hide();
            $(".dealer-title").hide();
            $(".message-label").html("Black Jack!! Gana el Dealer");
            $(".message-player").html("Jugador: " + player_points + " puntos");
            $(".message-dealer").html("Dealer: " + dealer_points + " puntos");
            insert_ganador(2);
        } else if (data == 1) {
            $(".message-winner").show();
            $(".deck").hide();
            $(".player-title").hide();
            $(".dealer-title").hide();
            $(".loading").hide();
            $(".message-label").html("Gana el Jugador!!");
            $(".message-player").html("Jugador: " + player_points + " puntos");
            $(".message-dealer").html("Dealer: " + dealer_points + " puntos");
            insert_ganador(1);
        } else if (data == 2) {
            $(".message-winner").show();
            $(".deck").hide();
            $(".player-title").hide();
            $(".dealer-title").hide();
            $(".message-label").html("Gana el Dealer!!");
            $(".message-player").html("Jugador: " + player_points + " puntos");
            $(".message-dealer").html("Dealer: " + dealer_points + " puntos");
            insert_ganador(2);
        } else if(dealer_play > 0){
            get_card_dealer(deck_id, 2);
        }
    });
}

function rotar_baraja() {
    $(".deck-div").append('<img class="loaging-deck" src="/images/loading-deck.gif" />');
    $(".image-deck").hide();

    $.ajax({
        type: "PUT",
        url: "/api/baraja/" + deck_id
    }).done(function (data) {
        $(".image-deck").show();
        $(".loaging-deck").hide();
    });

}

function get_reporte() {
    $.ajax({
        type: "GET",
        url: "/api/juego/"
    }).done(function (data) {
        $(".reporte").html("Partidas ganadas: " + data.Ganados + " - " + "Partidas perdidas: " + data.Perdidos + " - " + "Partidas empatadas: " + data.Empatados);
    });
}

function insert_ganador(ganador) {
    $.ajax({
        type: "PUT",
        url: "/api/juego/" + ganador
    }).done(function (data) {
        get_reporte();
    }).error(function (error) {
        alert("error");
    });
}