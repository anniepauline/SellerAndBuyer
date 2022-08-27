

// The following example creates five accessible and
// focusable markers.
function initMap() {
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 12,
        center: { lat: 34.84555, lng: -111.8035 },
        mapTypeId: 'roapmap'
    });
    // Set LatLng and title text for the markers. The first marker (Boynton Pass)
    // receives the initial focus when tab is pressed. Use arrow keys to
    // move between markers; press tab again to cycle through the map controls.
    const mapsMarkerBuyer = [
        [{ lat: 34.8791806, lng: -111.8265049 }, "Boynton Pass"],
        [{ lat: 34.8559195, lng: -111.7988186 }, "Rbell Rock"],

    ];
    const mapsMarkerSeller = [[{ lat: 34.800326, lng: -111.7665047 }, "Boynton Pass"]];
    //location stores string lat and lng
    //locationResult stores string lat and lng in an array
    //locationObj is an object stores key value pairs
    // if using db:
    //push lat and lng from db  into location array
    //add info window text into infoText variable

    var location = [];
    var locationObj;
    var cityCircle;
    var key = ['lat', 'lng'];
    location.push(" 34.800356 -111.5665047");
    var infoText = "some place";
    location.forEach(function (element) {
        var locationResult = element.trim().split(/\s+/);
        locationResult[0] = parseFloat(locationResult[0])
        locationResult[1] = parseFloat(locationResult[1])
        locationObj = Object.assign({}, ...key.map((e, i) => ({ [e]: locationResult[i] })))
        console.log(locationObj);
        var arr = [];
        arr.push(locationObj, infoText);
        mapsMarkerBuyer.push(arr);
    });
    console.log(mapsMarkerBuyer);
    // Create an info window to share between markers.
    const infoWindow = new google.maps.InfoWindow();

    // creatting radius-range for seller 
    mapsMarkerSeller.forEach(([position]) => {
        cityCircle = new google.maps.Circle({
            strokeColor: "#FF0000",
            strokeOpacity: 0.8,
            strokeWeight: 1,
            fillOpacity: 0.18,
            map,
            center: position,
            radius: Math.sqrt(50) * 100,
        })
    });
    // function to check if buyer is in seller range
    function isMarkerInArea(circle, marker) {
        return (circle.getBounds().contains(marker))
    };

    // display buyer marker that are only in  seller radius.
    mapsMarkerBuyer.forEach(([position, title], i) => {
        if (isMarkerInArea(cityCircle, position)) {
            const marker = new google.maps.Marker({
                position,
                map,
                title: `${i + 1}. ${title}`,
                label: `${i + 1}`,
                optimized: true,
            });

            // Add a click listener for each marker, and set up the info window.
            marker.addListener("click", () => {
                infoWindow.close();
                infoWindow.setContent(marker.getTitle());
                infoWindow.open(marker.getMap(), marker);
                map.setZoom(18);
                map.setCenter(data.location);
            });
        }

    });

}

window.initMap = initMap;