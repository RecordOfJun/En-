package view;
import javax.swing.*;

import utility.ListenerManagement;
import view.mainFrame.signUpButtonAction;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
public class LoginPanel extends JPanel {
	private Image backgroundImage=new ImageIcon("images/space.jpg").getImage().getScaledInstance(1000, 800, Image.SCALE_DEFAULT);
	private JTextField idText=new JTextField();
	private JPasswordField pwText=new JPasswordField();
	private JLabel idLabel=new JLabel("ID");
	private JLabel pwLabel=new JLabel("PW");
	private JButton loginButton=new JButton("로그인");
	private JButton pwFindButton=new JButton("아이디/비밀번호 찾기");
	public JButton singUpButton=new JButton("회원가입");
	
	public LoginPanel() {
		setSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));
		setPreferredSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));	
		setLayout(null);
		setTextField();
		setLabel();
		setButton();
	}
	
	private void setTextField() {
		idText.setBounds(420, 450, 220, 50);
		ListenerManagement.getInstance().linkTextLengthLimited(20, idText);
		idText.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		pwText.setBounds(420, 525, 220, 50);
		ListenerManagement.getInstance().linkTextLengthLimited(20, pwText);
		pwText.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		this.add(idText);
		this.add(pwText);
	}
	
	private void setLabel() {
		idLabel.setBounds(370, 450, 100, 50);
		pwLabel.setBounds(350, 525, 100, 50);
		idLabel.setForeground(Color.white);
		idLabel.setFont(new Font("맑은 고딕",Font.BOLD,30));
		pwLabel.setForeground(Color.white);
		pwLabel.setFont(new Font("맑은 고딕",Font.BOLD,30));
		this.add(idLabel);
		this.add(pwLabel);
	}
	
	private void setButton() {
		loginButton.setBounds(350, 590, 300, 50);
		pwFindButton.setBounds(350, 645, 300, 50);
		pwFindButton.addActionListener(new searchButtonAction());
		singUpButton.setBounds(350, 700, 300, 50);
		this.add(loginButton);
		this.add(pwFindButton);
		this.add(singUpButton);
	}
	
	public void paintComponent(Graphics g) {
		g.drawImage(backgroundImage, 0,0,null);
		setOpaque(false);
	}
	
	public class searchButtonAction implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			UserSearchingFrame searchFrame=new UserSearchingFrame();
		}
	}
}
