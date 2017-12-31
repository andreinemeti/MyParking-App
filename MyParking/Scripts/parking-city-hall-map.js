

var locations = [
    ['Parking City Hall, Parking places: 382', 46.767282, 23.585920, 1],
    ['City Hall', 46.769031, 23.584622, 2]
];

var map = new google.maps.Map(document.getElementById('map-parking-city-hall'), {
    zoom: 13,

    center: new google.maps.LatLng(46.76, 23.58),
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
