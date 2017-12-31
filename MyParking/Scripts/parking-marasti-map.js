

var locations = [
    ['Strada Fabricii, Parking places: 310', 46.788030, 23.615093, 1],
    ['Calea Dorobantilor, Parking places: 105', 46.774454, 23.608774, 2]
];

var map = new google.maps.Map(document.getElementById('map-parking-marasti'), {
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
