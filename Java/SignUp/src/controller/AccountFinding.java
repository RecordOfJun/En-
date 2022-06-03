package controller;

import model.UserDAO;
import view.Dialog;

public class AccountFinding {
	public void FindID(String name,String personal) {
		String result=UserDAO.getInstance().FindID(name, personal);
		if(result.length()!=0) {
			Dialog.getInstance().informID(result);
			return;
		}
		Dialog.getInstance().alertNotExist();
	}
	
	public void FindPW(String name,String personal,String id) {
		String result=UserDAO.getInstance().FindPW(name, personal,id);
		if(result.length()!=0) {
			Dialog.getInstance().informPW(result);
			return;
		}
		Dialog.getInstance().alertNotExist();
	}
}
