package controller;
import model.*;
import utility.Constant;
public class Calculation {
	NumberList status;
	public Calculation() {
		status=new NumberList();
	}
	public double initAll() {
		status.setResult(0);
		status.setLastNumber(null);
		status.setLastOperator(null);
		status.setLastType(Constant.TYPE_NULL);
		return status.getResult();
	}
}
