package view;
import javax.swing.*;

import model.UserDAO;
import view.MainFrame.reviseToUserAction;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
public class UserPanel extends JPanel {
	private Image backgroundImage=new ImageIcon("images/secret.jpg").getImage().getScaledInstance(1280, 720, Image.SCALE_DEFAULT);
	public JButton logOutButton=new JButton("로그아웃");
	private JButton withdrawalButton=new JButton("회원탈퇴");
	public JButton reviseButton=new JButton("정보수정");
	public String id;
	public String password;
	public SignUpPanel revisePanel=new SignUpPanel();
	private MainFrame mainFrame;
	
	public UserPanel(MainFrame mainFrame) {
		this.mainFrame=mainFrame;
		setSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));
		setPreferredSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));	
		setLayout(null);
		setButton();
	}
	
	private void setButton() {
		logOutButton.setBounds(450, 400, 300, 50);
		withdrawalButton.setBounds(450, 450, 300, 50);
		withdrawalButton.addActionListener(new withdrawalAction());
		reviseButton.setBounds(450, 500, 300, 50);
		this.add(logOutButton);
		this.add(reviseButton);
		this.add(withdrawalButton);
	}
	
	public void paintComponent(Graphics g) {
		g.drawImage(backgroundImage, 0,0,null);
		setOpaque(false);
	}
	
	public class withdrawalAction implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			DeleteFrame deleteFrame=new DeleteFrame(id, password,mainFrame);
		}
		
	}
}
