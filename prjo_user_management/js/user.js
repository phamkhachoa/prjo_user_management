jQuery(document).ready(function($) {
	//createUserInfor();
	var listErr;
	var userInfor;

	

	$("#createUser").click(function(event) {
		$(".dialog-form").addClass('showDialog');
		$(".nen_mo").addClass('showDialog');

		$.ajax({    //create an ajax request to display.php
        type: "POST",
        url: "/ListUser/ADM002Add",             
        dataType: "json",   //expect html to be returned                
        success: function(response){
        	$("#groupChoose").empty();
        	$("#codeLevel").empty();
        	var listGroup ;
        	var listJapan = "<option value=\"0\">Japanness Level</option>";; 
        	for (var i = 0; i < response.listMstGroup.length; i++ ){

        		listGroup += "<option value=" + response.listMstGroup[i].Group_id +">" + response.listMstGroup[i].Group_name + "</option>"; 		
        	}

        	for(var i =0; i < response.listMstJapan.length; i++){
        		listJapan += "<option value=" + response.listMstJapan[i].Code_level +">" + response.listMstJapan[i].Name_level + "</option>";
        	}

        	$("#groupChoose").append(listGroup);
        	$("#codeLevel").append(listJapan);
        }
    	});
	});



	$("#close").click(function(event) {
		$(".dialog-form").removeClass('showDialog');
		$(".nen_mo").removeClass('showDialog');
	});

	function createUserInfor() {
		userInfor = {
			Id :  $("#userId").val(),
			Login_name : $("#loginId").val(),
			GroupId : $("#groupChoose").val(),
			Name : $("#fullName").val(),
			Full_name_kana : $("#fullNameKana").val(),
			//BirthdayStr : $("#yearBirthday").val()+ "/" + $("#monthBirthday").val() +"/"+ $("#dateBirthday").val(),
			BirthdayStr : $("#dateBirthday").val()+ "/" + $("#monthBirthday").val() +"/"+ $("#yearBirthday").val(),
			Email : $("#email").val(),
			Tel : $("#tel").val(),
			Password : $("#password").val(),
			PasswordConfirm : $("#passwordConfirm").val(),
			Code_level : $("#codeLevel").val(),
			//StartDateStr : $("#yearStart").val() +"/" + $("#monthStart").val() + "/" +$("#dateStart").val(),
			StartDateStr : $("#dateStart").val() +"/" + $("#monthStart").val() + "/" +$("#yearStart").val(),
			//EndDateStr : $("#yearEnd").val() +"/" + $("#monthEnd").val() + "/" +$("#dateEnd").val(),
			EndDateStr : $("#dateEnd").val() +"/" + $("#monthEnd").val() + "/" +$("#yearEnd").val(),
			TotalStr : $("#total").val()

		}
		return userInfor;
	}

/*	$("#loginId").change(function(event) {
   		var loginId = $("#loginId").val();
		$.ajax({
			url: '/ListUser/validateLoginId',
			type: 'POST',
			dataType: 'json',
			data: {loginId: loginId},
			success: function(response){
				$("#messLoginId").empty();
				console.log(response);
				if(response == "Err"){
					$("#messLoginId").append('This login name has been used.');
				} else if(response == "Success") {
					//$("#messLoginId").append('This login name can be used. ');
				} else {
					$("#messLoginId").append('This login name must be not null.');
				}
			}
		});			
	});*/

/*	var emailRegex = /^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/;
	$("#email").change(function(event){
		$("#messEmail").empty();
		var email = $("#email").val();
		var result = emailRegex.test(email);
		if(!result) {
			$("#messEmail").append('\nInvalid Email');
		}

	});

	var phoneRegex = /^([0-9])+$/
	$("#phoneNumber").change(function(event){
		$("#messPhone").empty();
		//console.log("phone");
		var phone = $("#phoneNumber").val();
		var result = phoneRegex.test(phone);
		console.log(result);
		if(!result) {
			$("#messPhone").append('Invalid Phone Number.');
		}

	});

	var passRegex = /^([0-9a-zA-Z])+$/
	$("#password").change(function(event){
		$("#messPass").empty();
		//console.log("phone");
		var pass = $("#password").val();
		var result = passRegex.test(pass);
		console.log(result);
		if(!result) {
			$("#messPass").append('Invalid Password.');
		}
	});

	$("#passwordRe").change(function(event){
		$("#messPass").empty();
		//console.log("phone");
		var pass = $("#passwordRe").val();
		var result = (pass == $("#password").val());
		//console.log(result);
		if(!result) {
			$("#messPass").append('Password authentication must be like Password.');
		}
	});*/

/*	function checkBtnSubmit() {
		if(status == 0){
			$("#btnSubmit").prop('disabled', true);
			//$(':input[type="submit"]').prop('disabled', true);
		} else {
			$("#btnSubmit").prop('disabled', false);
		}
	}*/

/*	function getYear() {
		//var  date = new Date();
		let b = document.getElementById("yearB");
		let a = new Date().getFullYear();
		for (var i = 2000; i <= 2020; i++) {
			var opt = document.createElement('option');
    		opt.value = i;
    		opt.innerHTML = i;
    		b.appendChild(opt);
		}
		for (let i = 0; i < b.length; i++) {
			if(parseInt(b[i].value, 10) == a){
				console.log("ok");
				b[i].selected = true;
			}
		}
		//b.document.querySelector('[value=2019]').attr('selected', true);

		//$("#yearB").val(a).find("option[value=\""+ a +"\"]").attr('selected', true);

	}*/

	function setUserInfor(userInfor){

			$("#loginId04").empty();
			$("#groupId04").empty();
			$("#fullName04").empty();
			$("#fullNameKata04").empty();
			$("#birthDay04").empty();
			$("#tel04").empty();
			$("#email04").empty();
			$("#code_level04").empty();
			$("#startDate04").empty();
			$("#endDate04").empty();
			$("#total04").empty();

			$("#loginId04").append(userInfor.Login_name);
			$("#groupId04").append(userInfor.GroupId);
			$("#fullName04").append(userInfor.Name);
			$("#fullNameKata04").append(userInfor.Full_name_kana);
			$("#birthDay04").append(userInfor.BirthdayStr);
			$("#tel04").append(userInfor.Tel);
			$("#email04").append(userInfor.Email);
			$("#code_level04").append(userInfor.Code_level);
			$("#startDate04").append(userInfor.StartDateStr);
			$("#endDate04").append(userInfor.EndDateStr);
			$("#total04").append(userInfor.TotalStr);
	}

	$("#cancel04").click(function(event){
		$(".dialog-form-confirm").removeClass('showDialog');
		$(".dialog-form").addClass('showDialog');
	});

	$("#cancel03").click(function(event){
		$(".dialog-form").removeClass('showDialog');
		//$(".dialog-form").addClass('showDialog');
		$(".nen_mo").removeClass('showDialog');
	});

	$("#btnSubmit").click(function(event){
		$("#validateTips").empty();
		userInfor = createUserInfor();
		var json = JSON.stringify(userInfor);
		$.ajax({
			url: '/ListUser/validateUserInfor',
			type: 'POST',
			contentType: "application/json",
			dataType: 'json',
			//data: JSON.stringify(test),
			data: json,
			success: function(response){
				console.log(response.length);
				if(response.length !=0){
					var listErr ="";

					$.each(response,function(index, value){
						listErr += "<p>" + value + "</p>"
					});
					//console.log(listErr);
					$("#validateTips").append(listErr);
				} else {
					console.log("success");
					$(".dialog-form").removeClass('showDialog');
					//$(".nen_mo").removeClass('showDialog');
					$(".dialog-form-confirm").addClass('showDialog');
					setUserInfor(userInfor);
				}
			}
		});
	});


	$("#addUser").click(function(event){
		$.ajax({
			url: '/ListUser/AddUser',
			type: 'POST',
			contentType: "application/json",
			dataType: 'json',
			//data: JSON.stringify(test),
			data: JSON.stringify(userInfor),
			success: function(response){
				if(response == true){
					$(".dialog-form-confirm").removeClass('showDialog');
					$(".updateSuccess").addClass('showDialog');
				}
				//console.log(response);
			}
		})
	})

	$(".viewUser").click(function(event){
		//event.preventDefault();
		console.log($(this).text());
		$(".viewUser-dialog").addClass('showDialog');
		$(".nen_mo").addClass('showDialog');
		$.ajax({
			url: '/ListUser/ViewUser',
			type: 'POST',
			contentType: "application/json",
			dataType: 'json',
			data: JSON.stringify($(this).text()),
			success: function(response){

			}
		});

	});

});





