markerlessAR: What actually handles rendering the camera video stream and positioning the camera relative to the scene along with grabbing the gyroscope rotations.

Pinchzoom: handles the zooming in and out by changing camera field of view

cardArea: Handles taking new card objects and adding them to the list of cards. Positioning all cards in the collections and proper orientation. Also if importDeck is called handles the http request and loading all of the images into the card objects

createGroup: Creates a collection handler at the position of the camera forward

importDeck: takes the deck url from the inputfield and generates the card Area object with these cards loaded in

lookAtCamera: handles pointing at the camera or another object if specified

setDistance: will position an object closer/further from the camera by a set distance using normalized vector of their positions

touchScript: Handles touch coordinates/mouse clicks to raycast interaction and handling parenting to markerlessAR prefab /deparenting 
