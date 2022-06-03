package view;
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import utility.ListenerManagement;
public class UserSearchingFrame extends JFrame {
	private Container container=getContentPane();
	private JLabel nameLabel=new JLabel("이름");
	private JLabel personalLabel=new JLabel("주민번호");
	private JLabel idLabel=new JLabel("ID");
	private JTextField nameField=new JTextField();
	private JTextField birthField=new JTextField();
	private JPasswordField personalField=new JPasswordField();
	private JTextField idField=new JTextField();
	private JButton idSearchButton=new JButton("아이디 찾기");
	private JButton pwSearchButton=new JButton("비밀번호 찾기");
	private JButton searchButton=new JButton("검색");
	
	public UserSearchingFrame() {
		setContainer();
		setLabel();
		setTextField();
		setButton();
		hideIDForm();
	}
	
	private void setContainer() {
		setLayout(null);
		setTitle("아이디/비밀번호 검색");
		setSize(400,400);
		setResizable(false);
		setVisible(true);
	}
	
	private void setLabel() {
		setLabelFont(50,nameLabel);
		setLabelFont(110,personalLabel);
		setLabelFont(170,idLabel);
	}
	
	private void setLabelFont(int y,JLabel label) {
		label.setBounds(0, y, 100, 50);
		label.setForeground(Color.white);
		label.setFont(new Font("맑은 고딕",Font.BOLD,20));
		label.setHorizontalAlignment(JLabel.RIGHT);
		this.add(label);
	}
	
	private void setTextField() {
		nameField.setBounds(120, 50, 250, 50);
		nameField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		ListenerManagement.getInstance().linkTextLengthLimited(10, nameField);
		birthField.setBounds(120, 110, 120, 50);
		ListenerManagement.getInstance().linkTextLengthLimited(6, birthField);
		personalField.setBounds(250, 110, 120, 50);
		ListenerManagement.getInstance().linkTextLengthLimited(7, personalField);
		birthField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		personalField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		idField.setBounds(120, 170, 250, 50);
		idField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		ListenerManagement.getInstance().linkTextLengthLimited(20, idField);
		this.add(birthField);
		this.add(idField);
		this.add(nameField);
		this.add(personalField);
	}
	
	private void setButton() {
		searchButton.setBounds(45, 280, 150, 60);
		idSearchButton.setBounds(205, 280, 150, 60);
		pwSearchButton.setBounds(205, 280, 150, 60);
		idSearchButton.addActionListener(new convertToIdForm());
		pwSearchButton.addActionListener(new convertToPasswordForm());
		this.add(searchButton);
		this.add(idSearchButton);
		this.add(pwSearchButton);
	}
	
	private void hideIDForm() {
		idLabel.setVisible(false);
		idField.setVisible(false);
		idSearchButton.setVisible(false);
		repaint();
		revalidate();
	}
	
	public class convertToPasswordForm implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			idLabel.setVisible(true);
			idField.setVisible(true);
			idSearchButton.setVisible(true);
			pwSearchButton.setVisible(false);
			repaint();
			revalidate();
		}
	}
	public class convertToIdForm implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			pwSearchButton.setVisible(true);
			hideIDForm();
			repaint();
			revalidate();
		}
	}
}
