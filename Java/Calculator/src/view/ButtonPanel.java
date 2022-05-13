package view;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import utility.Constant;

public class ButtonPanel extends JPanel {
	private JButton[] numberButton=new JButton[10];
	private JButton negativeButton=new JButton("+/-");
	private JButton floatButton=new JButton(".");
	private JButton[] topButtons=new JButton[4];
	private JButton[] rightButtons=new JButton[4];
	
	
	public ButtonPanel() {
		setButton();
		setPanel();
		setAdapter();	
	}
	
	//숫자버튼 초기화
	private void setButton() {
		for(int count=1;count<=10;count++) {
			numberButton[count-1]=new JButton(Integer.toString(count%10));
			numberButton[count-1].setBackground(Color.white);
			numberButton[count-1].setFont(new Font("맑은 고딕",Font.BOLD,Constant.NUMBER_BUTTON_FONT_SIZE));
		}
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
		for(int count=0;count<10;count++)
			numberButton[count].addMouseListener(new ButtonFocusAdapter());
		floatButton.addMouseListener(new ButtonFocusAdapter());
		negativeButton.addMouseListener(new ButtonFocusAdapter());
		for(int count=0;count<4;count++)
			topButtons[count].addMouseListener(new ButtonFocusAdapter());
		for(int count=0;count<3;count++)
			rightButtons[count].addMouseListener(new ButtonFocusAdapter());
		rightButtons[3].addMouseListener(new EqualButtonFocusAdapter());
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
}
