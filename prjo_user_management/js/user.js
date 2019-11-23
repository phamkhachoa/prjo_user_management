jQuery(document).ready(function($) {
	$("#createUser").click(function(event) {
		$(".dialog-form").addClass('showDialog');
		$(".nen_mo").addClass('showDialog');
		$.ajax({    //create an ajax request to display.php
        type: "POST",
        url: "/ListUser/ADM002Add",             
        dataType: "json",   //expect html to be returned                
        success: function(response){

        	$("#groupChoose").empty();
        	$("#japanLevel").empty();
        	var listGroup = "<option value=\"0\">Group</option>";
        	var listJapan = "<option value=\"0\">Japanness Level</option>";; 
        	for (var i = 0; i < response.listMstGroup.length; i++ ){

        		listGroup += "<option value=" + response.listMstGroup[i].Group_id +"\">" + response.listMstGroup[i].Group_name + "</option>"; 		
        	}

        	for(var i =0; i < response.listMstJapan.length; i++){
        		listJapan += "<option value=" + response.listMstJapan[i].Code_level +"\">" + response.listMstJapan[i].Name_level + "</option>";
        	}

        	$("#groupChoose").append(listGroup);
        	$("#japanLevel").append(listJapan);
        }
    	});
	});

	$("#close").click(function(event) {
		$(".dialog-form").removeClass('showDialog');
		$(".nen_mo").removeClass('showDialog');
	});
});