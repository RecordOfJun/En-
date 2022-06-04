package view;
import javax.swing.*;

import model.UserDAO;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
public class DeleteFrame extends JFrame {
	private Container container=getContentPane();
	private JLabel label=new JLabel("비밀번호 입력");
	private JPasswordField passwordField=new JPasswordField();
	private JButton deleteButton=new JButton("확 인");
	private String password;
	private String id;
	private MainFrame mainFrame;
	private DeleteFrame deleteFrame;
	
	public DeleteFrame(String id,String password,MainFrame mainFrame) {
		this.mainFrame=mainFrame;
		this.id=id;
		this.password=password;
		this.deleteFrame=this;
		setComponent();
		setVisible(true);
	}
	
	private void setComponent() {
		setTitle("회원탈퇴");
		setSize(500,300);
		setResizable(false);
		setLayout(null);
		label.setForeground(Color.white);
		label.setBounds(0,100 , 200, 50);
		label.setFont(new Font("맑은 고딕",Font.BOLD,20));
		passwordField.setBounds(150,100,300,50);
		deleteButton.setBounds(150, 200, 200, 50);
		deleteButton.addActionListener(new deleteAction());
		container.add(label);
		container.add(deleteButton);
		container.add(passwordField);
	}
	
	public class deleteAction implements ActionListener{
		@Override
		public void actionPerformed(ActionEvent e) {
			if(String.valueOf(passwordField.getPassword()).equals(password)) {
				if(Dialog.getInstance().askDelete()==JOptionPane.YES_OPTION) {
					UserDAO.getInstance().deleteUser(id);
					Dialog.getInstance().deleteSucess();
					mainFrame.container.remove(mainFrame.userPanel);
					mainFrame.container.add(mainFrame.loginPanel);
					mainFrame.repaint();
					mainFrame.revalidate();
					deleteFrame.dispose();
				}
				return;
			}
			
			Dialog.getInstance().deleteFail();
		}
	}
}
