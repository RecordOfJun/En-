package controller;

import view.mainFrame;

public class MainController {
	private mainFrame frame;
	private AccountCreation accountCreation;
	private AccountFinding accountFinding;
	public MainController() {
		this.frame=new mainFrame();
		this.accountCreation=new AccountCreation();
		this.accountFinding=new AccountFinding();
	}
}
