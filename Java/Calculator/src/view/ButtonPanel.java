package view;
import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;

import javax.swing.*;
import utility.Constant;

public class ButtonPanel extends JPanel {
	private JButton[] numberButton=new JButton[10];
	private JButton negativeButton=new JButton("+/-");
	private JButton floatButton=new JButton(".");
	private JButton[] topButtons=new JButton[4];
	private JButton[] rightButtons=new JButton[4];
	public ArrayList<JButton> buttons=new ArrayList<JButton>();
	
	public ButtonPanel() {
		setButton();
		setPanel();
		setAdapter();	
	}
	
	//숫자버튼 초기화
	private void setButton() {
		for(int count=0;count<9;count++) {
			numberButton[count]=new JButton(Integer.toString(7-(count/3)*3+count%3));
			numberButton[count].setBackground(Color.white);
			numberButton[count].setFont(new Font("맑은 고딕",Font.BOLD,Constant.NUMBER_BUTTON_FONT_SIZE));
		}
		numberButton[9]=new JButton("0");
		numberButton[9].setBackground(Color.white);
		numberButton[9].setFont(new Font("맑은 고딕",Font.BOLD,Constant.NUMBER_BUTTON_FONT_SIZE));
		topButtons[0]=new JButton("CE");
		topButtons[0].setFont(new Font("맑은 고딕",Font.PLAIN,Constant.TOP_BUTTON_FONT_SIZE));
		topButtons[1]=new JButton("C");
		topButtons[1].setFont(new Font("맑은 고딕",Font.PLAIN,Constant.TOP_BUTTON_FONT_SIZE));
		topButtons[2]=new JButton("\u232B");
		topButtons[3]=new JButton("÷");
		rightButtons[0]=new JButton("×");
		rightButtons[1]=new JButton("+");
		rightButtons[2]=new JButton("-");
		rightButtons[3]=new JButton("=");
		negativeButton.setBackground(Color.white);
		floatButton.setBackground(Color.white);
	}
	private void setAdapter() {
		for(int count=0;count<10;count++) {
			numberButton[count].addMouseListener(new ButtonFocusAdapter());
			buttons.add(numberButton[count]);
		}
		floatButton.addMouseListener(new ButtonFocusAdapter());
		buttons.add(floatButton);
		negativeButton.addMouseListener(new ButtonFocusAdapter());
		buttons.add(negativeButton);
		for(int count=0;count<4;count++) {
			topButtons[count].addMouseListener(new ButtonFocusAdapter());
			buttons.add(topButtons[count]);
		}
		for(int count=0;count<3;count++) {
			rightButtons[count].addMouseListener(new ButtonFocusAdapter());
			buttons.add(rightButtons[count]);
		}
		rightButtons[3].addMouseListener(new EqualButtonFocusAdapter());
		buttons.add(rightButtons[3]);
	}
	
	private void setPanel() {
		this.setLayout(new GridLayout(5,4,1,1));
		for(int count=0;count<4;count++) {
			topButtons[count].setBackground(new Color(Constant.CHARACTER_BUTTON_RGB,Constant.CHARACTER_BUTTON_RGB,Constant.CHARACTER_BUTTON_RGB));
			topButtons[count].setBorder(null);
			if(count==3)
				topButtons[count].setFont(new Font("맑은 고딕",Font.PLAIN,Constant.RIGHT_BUTTON_FONT_SIZE));
			this.add(topButtons[count]);
		}
		topButtons[2].setFont(new Font(null,Font.PLAIN,20));
		int rightCount=0;
		for(int count=0;count<10;count++) {
			if(count%3==0&&count!=0) {
				rightButtons[rightCount].setBackground(new Color(Constant.CHARACTER_BUTTON_RGB,Constant.CHARACTER_BUTTON_RGB,Constant.CHARACTER_BUTTON_RGB));
				rightButtons[rightCount].setBorder(null);
				rightButtons[rightCount].setFont(new Font("맑은 고딕",Font.PLAIN,Constant.RIGHT_BUTTON_FONT_SIZE));
				this.add(rightButtons[rightCount]);
				rightCount++;
			}
			this.add(numberButton[count]);
			numberButton[count].setBorder(null);
		}
		negativeButton.setBorder(null);
		negativeButton.setFont(new Font("맑은 고딕",Font.BOLD,Constant.NUMBER_BUTTON_FONT_SIZE));
		floatButton.setBorder(null);
		negativeButton.setFont(new Font("맑은 고딕",Font.BOLD,Constant.NUMBER_BUTTON_FONT_SIZE));
		this.add(negativeButton);
		this.add(numberButton[9]);
		this.add(floatButton);
		rightButtons[rightCount].setBorder(null);
		rightButtons[rightCount].setFont(new Font("맑은 고딕",Font.BOLD,Constant.RIGHT_BUTTON_FONT_SIZE));
		rightButtons[rightCount].setBackground(new Color(Constant.EQUAL_BUTTON_R,Constant.EQUAL_BUTTON_G,Constant.EQUAL_BUTTON_B));
		this.add(rightButtons[rightCount]);
		this.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
		
	}
	private class ButtonFocusAdapter extends MouseAdapter{
		Color color;
		public void mouseEntered(MouseEvent e) {
			color=e.getComponent().getBackground();
			e.getComponent().setBackground(Color.LIGHT_GRAY);
		}
		public void mouseExited(MouseEvent e) {
			e.getComponent().setBackground(color);
		}
	}
	private class EqualButtonFocusAdapter extends MouseAdapter{
		Color color;
		public void mouseEntered(MouseEvent e) {
			color=e.getComponent().getBackground();
			e.getComponent().setBackground(new Color(70,153,219));
		}
		public void mouseExited(MouseEvent e) {
			e.getComponent().setBackground(color);
		}
	}
	public void appendAdapter(MouseListener adapter) {
		for(int count=0;count<10;count++)
			numberButton[count].addMouseListener(adapter);
		floatButton.addMouseListener(adapter);
		negativeButton.addMouseListener(adapter);
		for(int count=0;count<4;count++) {
			topButtons[count].addMouseListener(adapter);
			rightButtons[count].addMouseListener(adapter);
		}
		System.out.println(floatButton.getActionListeners().length);
		
	}
	public void setButtonEnable(boolean isAble) {
		for(int count=0;count<3;count++) {
			rightButtons[count].setEnabled(isAble);
		}
		topButtons[3].setEnabled(isAble);
		negativeButton.setEnabled(isAble);
		floatButton.setEnabled(isAble);
	}
	//버튼 누르면 색깔 변하는거 나중에 구현
	public class buttonColorAdapter extends KeyAdapter {
		public void keyPressed(KeyEvent e) {
			String key="";
			switch(e.getKeyCode()) {
				case KeyEvent.VK_ESCAPE:
					key="C";
					break;
				case KeyEvent.VK_DELETE:
					key="CE";
					break;
				case KeyEvent.VK_BACK_SPACE:
					key="\u232B";
					break;
				case KeyEvent.VK_F9:
					key="+/-";
					break;
				case KeyEvent.VK_ENTER:
					key="=";
					break;
			}
			switch(e.getKeyChar()) {
			case '.':
				key=".";
				break;
			case '0':case '1':case '2':case '3':case '4':case '5':case '6':case '7':case '8':case '9':
				key=String.valueOf(e.getKeyChar());
				break;
			case '/':
				key="÷";
				break;
			case'*':
				key="×";
				break;
			case'+':
				key="+";
				break;
			case'-':
				key="-";
			}
			if(key!="") {
				
			}
				
		}
	}
}
