

var locations = [
    ['Parking Manastur, Parking places: 100', 46.754846, 23.554986, 1],
    ['Strada Primaverii', 46.754130, 23.551641, 2]
];

var map = new google.maps.Map(document.getElementById('map-parking-manastur'), {
    zoom: 12,

    center: new google.maps.LatLng(46.75, 23.55),
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
