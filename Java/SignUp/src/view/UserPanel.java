package view;
import javax.swing.*;

import model.UserDAO;
import view.mainFrame.reviseToUserAction;

import java.awt.*;
public class UserPanel extends JPanel {
	private Image backgroundImage=new ImageIcon("images/space.jpg").getImage().getScaledInstance(1200, 720, Image.SCALE_DEFAULT);
	public JButton logOutButton=new JButton("로그아웃");
	private JButton withdrawalButton=new JButton("회원탈퇴");
	public JButton reviseButton=new JButton("정보수정");
	public String id;
	public SignUpPanel revisePanel=new SignUpPanel();
	
	public UserPanel() {
		setSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));
		setPreferredSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));	
		setLayout(null);
		setButton();
	}
	
	private void setButton() {
		logOutButton.setBounds(500, 500, 100, 50);
		withdrawalButton.setBounds(500, 550, 100, 50);
		reviseButton.setBounds(500, 600, 100, 50);
		this.add(logOutButton);
		this.add(reviseButton);
		this.add(withdrawalButton);
	}
	
	public void paintComponent(Graphics g) {
		g.drawImage(backgroundImage, 0,0,null);
		setOpaque(false);
	}
}
