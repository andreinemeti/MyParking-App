

var locations = [
    ['Parking Gheorgheni, Parking places: 317', 46.762617, 23.621702, 1],
    ['Aleea Baisoara', 46.764929, 23.623980, 2],
    ['Piata Cipariu, Parking Places: 100', 46.768646, 23.599278, 3]
];

var map = new google.maps.Map(document.getElementById('map-parking-gheorgheni'), {
    zoom: 13,

    center: new google.maps.LatLng(46.76, 23.62),
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
