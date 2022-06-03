package view;
import javax.swing.*;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
public class AdressFrame extends JFrame {
	public AdressFrame addressFrame;
	private Container container=getContentPane();
	public JTextField adressField=new JTextField();
	public JButton searchButton=new JButton("검 색");
	private JLabel label=new JLabel("검색어 입력");
	private JPanel adressPanel=new JPanel();
	public Box mainBox = Box.createVerticalBox();
	private JScrollPane scroll=new JScrollPane(adressPanel,ScrollPaneConstants.VERTICAL_SCROLLBAR_AS_NEEDED,ScrollPaneConstants.HORIZONTAL_SCROLLBAR_NEVER);
	private BoxLayout layout=new BoxLayout(adressPanel,BoxLayout.Y_AXIS);
	public AdressFrame() {
		container.setLayout(null);
		setResizable(false);
		setSize(400,600);
		setVisible(true);
		setComponents();
		addressFrame=this;
	}
	
	private void setComponents() {
		adressPanel.setLayout(layout);
		adressPanel.add(mainBox);
		adressPanel.setBackground(Color.white);
		scroll.getVerticalScrollBar().setUnitIncrement(10);
		label.setBounds(10, 10, 80, 50);
		adressField.setBounds(90, 10, 200, 50);
		searchButton.setBounds(300,10,80,50);
		scroll.setBounds(0, 100, 400, 500);
		container.add(label);
		container.add(adressField);
		container.add(searchButton);
		container.add(scroll);
	}
	
	public void addButton(String jibun,String road,JTextField adressField) {
		mainBox.remove(label);
		JButton button=new JButton();
		//button.setBorder(null);
		button.addActionListener(new setText(adressField));
		button.setBackground(Color.white);
		button.setHorizontalAlignment(SwingConstants.LEFT);
		button.setPreferredSize(new Dimension(400,100));
		button.setText("<html><p style=\"text-align:left;\">"+jibun+"<br>"+road+"</p></html>");
		//button.addMouseListener(new buttonFocusAdapter());
		mainBox.add(button,0);
		this.repaint();
		this.revalidate();
	}
	
	public class setText implements ActionListener{
		JTextField adressField;
		public setText(JTextField adressField) {
			this.adressField=adressField;
		}
		public void actionPerformed(ActionEvent e) {
			JButton button=(JButton)e.getSource();
			String text=button.getText().replace("<html><p style=\"text-align:right;\">","").replace("</p></html>","");
			String[] temporary=text.split("<br>");
			adressField.setFont(new Font("맑은 고딕",Font.PLAIN,15));
			adressField.setText(temporary[1]);
			addressFrame.dispose();
		}
	}
}
