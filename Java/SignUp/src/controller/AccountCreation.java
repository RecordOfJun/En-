package controller;

import java.util.ArrayList;

import model.UserDAO;
import view.Dialog;

public class AccountCreation {
	public void addAccount(ArrayList<String> userData) {
		UserDAO.getInstance().insertUser(userData.get(0), userData.get(1), userData.get(3), userData.get(4), userData.get(5), userData.get(6),userData.get(7));
		Dialog.getInstance().signUpSucess();
	}
	
	public boolean isCorrectData(boolean isCheckedID,boolean isCheckedPersonal,ArrayList<String> userData) {
		if(!isCheckedID) {
			Dialog.getInstance().alertIDCheck();
			return false;
		}
		if(!isCorrectPassword(userData.get(1), userData.get(2)))
			return false;
		if(isEmptyName(userData.get(3)))
			return false;
		if(!isCheckedPersonal) {
			Dialog.getInstance().alertPersonalCheck();
			return false;
		}
		if(!isCorrectPhoneNumber(userData.get(5)))
			return false;
		if(!isCorrectAdress(userData.get(6)))
			return false;
		return true;
	}
	
	private boolean isCorrectPassword(String password,String confirmPassword) {
		if(!password.matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@$!%*?&])[A-Za-z0-9@$!%*?&]{8,15}$")) {
			Dialog.getInstance().alertNotCorrectPassword();
			return false;
		}
		if(!password.equals(confirmPassword)) {
			Dialog.getInstance().alertNotSamePassword();
			return false;
		}
		return true;
	}
	
	private boolean isCorrectPhoneNumber(String phoneNumber) {
		if(phoneNumber.matches("^01([0|1|6|7|8|9])-?([0-9]{3,4})-?([0-9]{4})$")) {
			return true;
		}
		Dialog.getInstance().alertPhone();
		return false;
	}
	
	private boolean isCorrectAdress(String adress) {
		if(adress.length()!=0)
			return true;
		Dialog.getInstance().alertAdress();
		return false;
	}
	
	private boolean isEmptyName(String name) {
		if(name.equals("")) {
			Dialog.getInstance().alertName();
			return true;
		}
		return false;
	}
	
	public boolean isCorrectID(String id) {//id중복확인 버튼 리스너에 달아줌
		if(!id.matches("^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z0-9]{8,15}$")) {
			Dialog.getInstance().alertID();
			return false;
		}
		if(UserDAO.getInstance().isExistedID(id)){
			Dialog.getInstance().alertIDOverlap();
			return false;
		}
		Dialog.getInstance().idCheckSucess();
		return true;
	}
	public boolean isCorrectPersonal(String personal) {//id중복확인 버튼 리스너에 달아줌
		if(!personal.matches("[0-9]{2}([0][1-9]|[1][0-2])([0][1-9]|[1-2][0-9]|[3][0-1])[-]*[1-4][0-9]{6}")) {
			Dialog.getInstance().alertPersonal();
			return false;
		}
		if(UserDAO.getInstance().isExistedPersonal(personal)){
			Dialog.getInstance().alertPersonalOverlap();
			return false;
		}
		Dialog.getInstance().personalCheckSucess();
		return true;
	}
}
