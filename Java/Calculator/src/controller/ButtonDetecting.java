package controller;
import view.ButtonPanel;
import view.TextPanel;
import view.CalculatorFrame;
import java.awt.event.*;
import javax.swing.*;
import utility.Constant;
public class ButtonDetecting {
	private CalculatorFrame frame;
	private TextPanel textPanel;
	private ButtonPanel buttonPanel;
	private Calculation calculation;
	public ButtonDetecting(){
		frame=new CalculatorFrame();
		textPanel=frame.calculatings;
		buttonPanel=frame.buttons;
		calculation=new Calculation();
	}
	public void start(){
		frame.loadFrame();
		buttonPanel.appendAdapter(new numberAdapter());
	}
	public class numberAdapter extends MouseAdapter{
		public void mouseReleased(MouseEvent e) {
			String character=getButtonText(e);
			//숫자 받아온걸로 가공
			//텍스트 최신화
			textPanel.presentNumber.setText((Double.toString(switchButton(character))));

		}
	}
	private String getButtonText(MouseEvent e) {
		JButton button=(JButton)e.getSource();
		return button.getText();
	}
	private double switchButton(String character) {
		double result;
		switch(character) {
			case"C":
				//전체 초기화=>리스트 내부의 수식내용도 전체 삭제
				result=calculation.initAll(); 
				break;
			case"CE":
				//직전 숫자만 삭제
				System.out.println("직전 수 초기화");
				result=1;
				break;
			case".":
				//직전 숫자만 삭제
				result=1;
				System.out.println("콤마");
				break;
			case"+/-":
				result=1;
				//직전 숫자만 삭제
				System.out.println("부호전환");
				break;
			case"=":
				result=1;
				//직전 숫자만 삭제
				System.out.println("계산");
				break;
			case"\u232B":
				result=1;
				//직전 숫자만 삭제
				System.out.println("백스페이스");
				break;	
			case"÷": case"×": case"+": case"-":
				//직전 숫자만 삭제
				result=1;
				System.out.println("연산자");
				break;
			default:
				result=1;
				System.out.println("숫자");
				break;
			
		}
		return result;
	}
}
