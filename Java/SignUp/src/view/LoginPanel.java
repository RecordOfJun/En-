package view;
import javax.swing.*;

import utility.ListenerManagement;
import view.mainFrame.signUpButtonAction;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
public class LoginPanel extends JPanel {
	private Image backgroundImage=new ImageIcon("images/FBI2.jpg").getImage().getScaledInstance(1280, 720, Image.SCALE_DEFAULT);
	public JTextField idText=new JTextField();
	public JPasswordField pwText=new JPasswordField();
	private JLabel idLabel=new JLabel("Agent ID");
	private JLabel pwLabel=new JLabel("Password");
	public JButton loginButton=new JButton("로그인");
	public JButton pwFindButton=new JButton("아이디/비밀번호 찾기");
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
		idText.setBounds(400, 400, 400, 50);
		ListenerManagement.getInstance().linkTextLengthLimited(20, idText);
		idText.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		pwText.setBounds(400, 500, 400, 50);
		ListenerManagement.getInstance().linkTextLengthLimited(20, pwText);
		pwText.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		this.add(idText);
		this.add(pwText);
	}
	
	private void setLabel() {
		idLabel.setBounds(400, 350, 200, 50);
		pwLabel.setBounds(400, 450, 200, 50);
		idLabel.setForeground(Color.white);
		idLabel.setFont(new Font("맑은 고딕",Font.BOLD,30));
		idLabel.setHorizontalAlignment(JLabel.LEFT);
		pwLabel.setForeground(Color.white);
		pwLabel.setFont(new Font("맑은 고딕",Font.BOLD,30));
		pwLabel.setHorizontalAlignment(JLabel.LEFT);
		this.add(idLabel);
		this.add(pwLabel);
	}
	
	private void setButton() {
		loginButton.setBounds(850, 400, 300, 50);
		loginButton.setFocusable(false);
		pwFindButton.setBounds(850, 450, 300, 50);
		pwFindButton.setFocusable(false);
		pwFindButton.addActionListener(new searchButtonAction());
		singUpButton.setBounds(850, 500, 300, 50);
		singUpButton.setFocusable(false);
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
	
	
	
	public String getIdAndPw() {
		return idText.getText()+"/"+String.valueOf(pwText.getPassword());
	}
}
