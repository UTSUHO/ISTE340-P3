using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogaardP3
{
    public partial class ResourcesForm : Form
    {
        public ResourcesForm(Resources me, String para)
        {
            InitializeComponent();
            this.Text = para;
            if (para == "StudyAbroad")
            {
                label1.Text = me.studyAbroad.description;
                label1.Text += Environment.NewLine + me.studyAbroad.places[0].nameOfPlace;
                label1.Text += Environment.NewLine + me.studyAbroad.places[0].description;
                label1.Text += Environment.NewLine + me.studyAbroad.places[1].nameOfPlace;
                label1.Text += Environment.NewLine + me.studyAbroad.places[1].description;

            }
            else if (para == "StudentServices")
            {
                label1.Text = me.studentServices.academicAdvisors.title;
                label1.Text += Environment.NewLine + me.studentServices.academicAdvisors.description;
                label1.Text += Environment.NewLine + me.studentServices.academicAdvisors.faq.title;
                label1.Text += Environment.NewLine + me.studentServices.academicAdvisors.faq.contentHref;
                label1.Text += Environment.NewLine + me.studentServices.professonalAdvisors.title;
                label1.Text += Environment.NewLine + me.studentServices.professonalAdvisors.advisorInformation[0].name;
                label1.Text += ";  " + me.studentServices.professonalAdvisors.advisorInformation[0].department;
                label1.Text += ";  " + me.studentServices.professonalAdvisors.advisorInformation[0].email;
                label1.Text += Environment.NewLine + me.studentServices.professonalAdvisors.advisorInformation[1].name;
                label1.Text += ";  " + me.studentServices.professonalAdvisors.advisorInformation[1].department;
                label1.Text += ";  " + me.studentServices.professonalAdvisors.advisorInformation[1].email;
                label1.Text += Environment.NewLine + me.studentServices.professonalAdvisors.advisorInformation[2].name;
                label1.Text += ";  " + me.studentServices.professonalAdvisors.advisorInformation[2].department;
                label1.Text += ";  " + me.studentServices.professonalAdvisors.advisorInformation[2].email;
                label1.Text += Environment.NewLine + me.studentServices.facultyAdvisors.title;
                label1.Text += Environment.NewLine + me.studentServices.facultyAdvisors.description;
                label1.Text += Environment.NewLine + me.studentServices.istMinorAdvising.title;
                label1.Text += Environment.NewLine + me.studentServices.istMinorAdvising.minorAdvisorInformation[0].title;
                label1.Text += ";  " + me.studentServices.istMinorAdvising.minorAdvisorInformation[0].advisor;
                label1.Text += ";  " + me.studentServices.istMinorAdvising.minorAdvisorInformation[0].email;
                label1.Text += Environment.NewLine + me.studentServices.istMinorAdvising.minorAdvisorInformation[1].title;
                label1.Text += ";  " + me.studentServices.istMinorAdvising.minorAdvisorInformation[1].advisor;
                label1.Text += ";  " + me.studentServices.istMinorAdvising.minorAdvisorInformation[1].email;
                label1.Text += Environment.NewLine + me.studentServices.istMinorAdvising.minorAdvisorInformation[2].title;
                label1.Text += ";  " + me.studentServices.istMinorAdvising.minorAdvisorInformation[2].advisor;
                label1.Text += ";  " + me.studentServices.istMinorAdvising.minorAdvisorInformation[2].email;
                label1.Text += Environment.NewLine + me.studentServices.istMinorAdvising.minorAdvisorInformation[3].title;
                label1.Text += ";  " + me.studentServices.istMinorAdvising.minorAdvisorInformation[3].advisor;
                label1.Text += ";  " + me.studentServices.istMinorAdvising.minorAdvisorInformation[3].email;
                label1.Text += Environment.NewLine + me.studentServices.istMinorAdvising.minorAdvisorInformation[4].title;
                label1.Text += ";  " + me.studentServices.istMinorAdvising.minorAdvisorInformation[4].advisor;
                label1.Text += ";  " + me.studentServices.istMinorAdvising.minorAdvisorInformation[4].email;
                label1.Text += Environment.NewLine + me.studentServices.istMinorAdvising.minorAdvisorInformation[5].title;
                label1.Text += ";  " + me.studentServices.istMinorAdvising.minorAdvisorInformation[5].advisor;
                label1.Text += ";  " + me.studentServices.istMinorAdvising.minorAdvisorInformation[5].email;
                label1.Text += Environment.NewLine + me.studentServices.istMinorAdvising.minorAdvisorInformation[6].title;
                label1.Text += ";  " + me.studentServices.istMinorAdvising.minorAdvisorInformation[6].advisor;
                label1.Text += ";  " + me.studentServices.istMinorAdvising.minorAdvisorInformation[6].email;
                label1.Text += Environment.NewLine + me.studentServices.istMinorAdvising.minorAdvisorInformation[7].title;
                label1.Text += ";  " + me.studentServices.istMinorAdvising.minorAdvisorInformation[7].advisor;
                label1.Text += ";  " + me.studentServices.istMinorAdvising.minorAdvisorInformation[7].email;

            }
            else if (para == "TutorsAndLabInformation")
            {
                label1.Text = me.tutorsAndLabInformation.description;
                label1.Text += Environment.NewLine + me.tutorsAndLabInformation.tutoringLabHoursLink;
            }
            else if (para == "StudentAmbassadors")
            {
                label1.Text = me.studentAmbassadors.title;
                label1.Text += Environment.NewLine + me.studentAmbassadors.subSectionContent[0].title;
                label1.Text += Environment.NewLine + me.studentAmbassadors.subSectionContent[0].description;
                label1.Text += Environment.NewLine + me.studentAmbassadors.subSectionContent[1].title;
                label1.Text += Environment.NewLine + me.studentAmbassadors.subSectionContent[1].description;
                label1.Text += Environment.NewLine + me.studentAmbassadors.subSectionContent[2].title;
                label1.Text += Environment.NewLine + me.studentAmbassadors.subSectionContent[2].description;
                label1.Text += Environment.NewLine + me.studentAmbassadors.subSectionContent[3].title;
                label1.Text += Environment.NewLine + me.studentAmbassadors.subSectionContent[3].description;
                label1.Text += Environment.NewLine + me.studentAmbassadors.subSectionContent[4].title;
                label1.Text += Environment.NewLine + me.studentAmbassadors.subSectionContent[4].description;
                label1.Text += Environment.NewLine + me.studentAmbassadors.subSectionContent[5].title;
                label1.Text += Environment.NewLine + me.studentAmbassadors.subSectionContent[5].description;
                label1.Text += Environment.NewLine + me.studentAmbassadors.subSectionContent[6].title;
                label1.Text += Environment.NewLine + me.studentAmbassadors.subSectionContent[6].description;
                label1.Text += Environment.NewLine + me.studentAmbassadors.applicationFormLink;
                label1.Text += Environment.NewLine + me.studentAmbassadors.note;

            }
            else if (para == "Forms")
            {
                label1.Text = me.forms.GetType().Name;
                label1.Text += Environment.NewLine + me.forms.graduateForms[0].formName;
                label1.Text += Environment.NewLine + me.forms.graduateForms[0].href;
                label1.Text += Environment.NewLine + me.forms.graduateForms[1].formName;
                label1.Text += Environment.NewLine + me.forms.graduateForms[1].href;
                label1.Text += Environment.NewLine + me.forms.graduateForms[2].formName;
                label1.Text += Environment.NewLine + me.forms.graduateForms[2].href;
                label1.Text += Environment.NewLine + me.forms.graduateForms[3].formName;
                label1.Text += Environment.NewLine + me.forms.graduateForms[3].href;
                label1.Text += Environment.NewLine + me.forms.graduateForms[4].formName;
                label1.Text += Environment.NewLine + me.forms.graduateForms[4].href;
                label1.Text += Environment.NewLine + me.forms.graduateForms[5].formName;
                label1.Text += Environment.NewLine + me.forms.graduateForms[5].href;
                label1.Text += Environment.NewLine + me.forms.graduateForms[6].formName;
                label1.Text += Environment.NewLine + me.forms.graduateForms[6].href;
            }
            else if (para == "CoopEnrollment")
            {
                label1.Text = me.coopEnrollment.title;
                label1.Text += Environment.NewLine + me.coopEnrollment.enrollmentInformationContent[0].title;
                label1.Text += Environment.NewLine + me.coopEnrollment.enrollmentInformationContent[0].description;
                label1.Text += Environment.NewLine + me.coopEnrollment.enrollmentInformationContent[1].title;
                label1.Text += Environment.NewLine + me.coopEnrollment.enrollmentInformationContent[1].description;
                label1.Text += Environment.NewLine + me.coopEnrollment.enrollmentInformationContent[2].title;
                label1.Text += Environment.NewLine + me.coopEnrollment.enrollmentInformationContent[2].description;
                label1.Text += Environment.NewLine + me.coopEnrollment.enrollmentInformationContent[3].title;
                label1.Text += Environment.NewLine + me.coopEnrollment.enrollmentInformationContent[3].description;
                label1.Text += Environment.NewLine + me.coopEnrollment.RITJobZoneGuidelink;

            }
        }
    }
}
