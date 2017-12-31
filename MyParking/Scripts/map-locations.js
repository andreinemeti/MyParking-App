

var locations = [
    ['Parking City Hall, Parking places: 382', 46.767282, 23.585920, 1],
    ['Parking Gheorgheni, Parking places: 317', 46.762617, 23.621702, 2],
    ['Piata Cipariu, Parking Places: 100', 46.768646, 23.599278, 3],
    ['Parking Manastur, Parking places: 100', 46.754846, 23.554986, 4],
    ['Strada Fabricii, Parking places: 310', 46.788030, 23.615093, 5],
    ['Calea Dorobantilor, Parking places: 105', 46.774454, 23.608774, 6],
    ['Parking Multiplex Leu, Parking places: 425', 46.774135, 23.593837, 7],
    ['Park2FLY, Parking places: 100', 46.784500, 23.654439, 8]
];

var map = new google.maps.Map(document.getElementById('map'), {
    zoom: 13,

    center: new google.maps.LatLng(46.77, 23.61),
    mapTypeId: google.maps.MapTypeId.ROADMAP
});



var infowindow = new google.maps.InfoWindow();

var marker, i;

for (i = 0; i < locations.length; i++) {
    marker = new google.maps.Marker({
        position: new google.maps.LatLng(locations[i][1], locations[i][2]),
        animation: google.maps.Animation.DROP,
        map: map
    });

    google.maps.event.addListener(marker, 'mouseover', (function (marker, i) {
        return function () {
            infowindow.setContent(locations[i][0]);
            infowindow.open(map, marker);
            marker.setAnimation(google.maps.Animation.BOUNCE);
        };
    })(marker, i));
    google.maps.event.addListener(marker, 'mouseout', (function (marker, i) {
        return function () {
            marker.setAnimation(null);
        };
    })(marker, i));
}
