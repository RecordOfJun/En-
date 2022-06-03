package controller;

import javax.swing.JButton;
import javax.swing.*;
import java.awt.*;
import view.mainFrame;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class MainController {
	private mainFrame frame;
	private Entrance entrance;
	private AccountCreation accountCreation;
	private AccountFinding accountFinding;
	private JButton loginButton;
	
	public MainController() {
		this.frame=new mainFrame();
		this.accountCreation=new AccountCreation();
		this.accountFinding=new AccountFinding();
		this.loginButton=frame.loginPanel.loginButton;
		this.entrance=new Entrance();
		setButton();
	}
	
	private void setButton() {
		loginButton.addActionListener(new loginAction());
	}
	
	public class loginAction implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			//아이디 비밀번호의 텍스트필드 값 받아오는 함수 호출
			String idAndPw=frame.loginPanel.getIdAndPw();
			//ENTRANCE클래스에서 아이디 비번 비교하고 화면전환
			if(entrance.isExistedID(idAndPw))
				frame.setUserPanel();
		}
	}
}
